using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 velocity;
    float acceleration = 40;
    float deceleration => acceleration;

    float pitchSpeed = 60;
    float rollSpeed = 90;

    public GameObject? presentPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            // Accelerate
            velocity += Vector3.forward * acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Brake
            velocity -= Vector3.forward * deceleration * Time.deltaTime;
        }

        var rotation = Quaternion.identity;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Pull Down
            rotation *= Quaternion.Euler(new Vector3(pitchSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Pull Down
            rotation *= Quaternion.Euler(new Vector3(-pitchSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation *= Quaternion.Euler(new Vector3(0, 0, rollSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation *= Quaternion.Euler(new Vector3(0, 0, -rollSpeed * Time.deltaTime));
        }

        transform.rotation = transform.rotation * rotation;
        transform.position += transform.rotation * velocity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            DropPresent();
        }
    }

    private void DropPresent()
    {
        if(presentPrefab != null)
        {
            var present = Instantiate(presentPrefab);
            present.transform.position = transform.position + -transform.up * 1;
            present.GetComponent<Rigidbody>().velocity = transform.rotation * velocity;
        }
    }

    private void FixedUpdate()
    {
        
    }
}

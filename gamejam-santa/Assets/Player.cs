using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 velocity;
    float acceleration = 40;
    float deceleration => acceleration;

    public float MinSpeed = 1;
    public float MaxSpeed = 10;

    public float PitchSpeed = 60;
    public float RollSpeed = 90;
    public float YawSpeed = 60;

    public GameObject presentPrefab;
    float presentDropShiftDistance = 1;

    float? timeSinceLastPresent = null;
    float timeBetweenPresents = 1.0f;
    bool wantsToDropPresent = false;

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

        velocity.z = Mathf.Clamp(velocity.z, MinSpeed, MaxSpeed);

        var rotation = Quaternion.identity;

        if (Input.GetKey(KeyCode.A))
        {
            rotation *= Quaternion.Euler(new Vector3(0, -YawSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation *= Quaternion.Euler(new Vector3(0, YawSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Pull Down
            rotation *= Quaternion.Euler(new Vector3(PitchSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Pull Down
            rotation *= Quaternion.Euler(new Vector3(-PitchSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation *= Quaternion.Euler(new Vector3(0, 0, RollSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation *= Quaternion.Euler(new Vector3(0, 0, -RollSpeed * Time.deltaTime));
        }

        transform.rotation = transform.rotation * rotation;
        transform.position += transform.rotation * velocity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            wantsToDropPresent = true;
        }

        timeSinceLastPresent += Time.deltaTime;

        if (wantsToDropPresent && (timeSinceLastPresent == null || timeSinceLastPresent > timeBetweenPresents))
        {
            DropPresent();
            wantsToDropPresent = false;
            timeSinceLastPresent = 0.0f;
        }
    }

    private void DropPresent()
    {
        if(presentPrefab != null)
        {
            var present = Instantiate(presentPrefab);
            present.transform.position = transform.position + -transform.up * presentDropShiftDistance;
            present.GetComponent<Rigidbody>().velocity = transform.rotation * velocity;
        }
    }

    private void FixedUpdate()
    {
        
    }
}

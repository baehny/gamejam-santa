using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float acceleration = 40;
    float deceleration => acceleration;

    public float MinSpeed = 1;
    public float MaxSpeed = 10;

    public float PitchSpeed = 60;
    public float RollSpeed = 90;
    public float YawSpeed = 60;

    void Update()
    {
        var velocity = GetComponent<Velocity>().velocity;
        if (Input.GetKey(KeyCode.W))
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

        GetComponent<Velocity>().velocity = velocity;

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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Second try at a player.
/// </summary>
public class Player2 : MonoBehaviour
{
    public float DefaultVelocity = 10;
    public float BoostedVelocity = 50;
    public float Acceleration = 200;
    public float Decceleration = 200;
    float currentVelocity;

    public float YawSpeed = 60;
    float currentYaw = 0;

    float currentPitch = 0;
    public float MaxPitch = 20;
    public float PitchSpeed = 100;

    void Start()
    {
        currentVelocity = DefaultVelocity;
    }
    // Update is called once per frame
    void Update()
    {
        var isBoosted = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var targetVelocity = isBoosted ? BoostedVelocity : DefaultVelocity;

        if (currentVelocity < targetVelocity)
        {
            currentVelocity += Time.deltaTime * Acceleration;
            currentVelocity = Math.Min(currentVelocity, targetVelocity);
        }
        else if (currentVelocity > targetVelocity)
        {
            currentVelocity -= Time.deltaTime * Decceleration;
            currentVelocity = Math.Max(currentVelocity, targetVelocity);
        }

        GetComponent<Velocity>().velocity = Vector3.forward * currentVelocity;



        var rotation = Quaternion.identity;

        if (Input.GetKey(KeyCode.A))
        {
            currentYaw -= YawSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentYaw += YawSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            currentPitch += Time.deltaTime * PitchSpeed;
            currentPitch = Math.Min(currentPitch, MaxPitch);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentPitch -= Time.deltaTime * PitchSpeed;
            currentPitch = Math.Max(currentPitch, -MaxPitch);
        }
        else
        {
            if (currentPitch > 0)
            {
                currentPitch -= Time.deltaTime * PitchSpeed;
                currentPitch = Math.Max(currentPitch, 0);
            }
            if (currentPitch < 0)
            {
                currentPitch += Time.deltaTime * PitchSpeed;
                currentPitch = Math.Min(currentPitch, 0);
            }
        }

        currentYaw = Mathf.DeltaAngle(0, currentYaw);

        transform.rotation = Quaternion.Euler(new Vector3(currentPitch, currentYaw, 0));
    }
}

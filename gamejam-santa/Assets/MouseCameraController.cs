using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    Quaternion neutralRotation;
    // Start is called before the first frame update
    void Start()
    {
        neutralRotation = this.GetComponent<Transform>().rotation;
    }

    Vector2 mouseMovement = Vector2.zero;
    float mouseDownTime = 0;
    Quaternion mouseRotation;

    // Update is called once per frame
    void Update()
    {
        var now = Time.time;

        var mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (!Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;
            mouseMovement = Vector2.zero;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;


            // var screenSize = new Vector2(Screen.width, Screen.height);
            // var relPos = mouseDelta / screenSize * 2 - new Vector2(1, 1);
            // mouseMovement += relPos;

            mouseMovement += mouseDelta;
            mouseRotation = Quaternion.Euler(
                -mouseMovement.y,
                mouseMovement.x,
                0);
            mouseDownTime = now;
        }

        var timeSinceMouseWasDown = now - mouseDownTime;

        float resetTime = 0.1f;

        float lerpFactor = Math.Min(timeSinceMouseWasDown / resetTime, 1);


        this.GetComponent<Transform>().localRotation = neutralRotation * Quaternion.Lerp(mouseRotation, Quaternion.identity, lerpFactor);
    }
}

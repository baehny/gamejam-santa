using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPresent : MonoBehaviour
{
    public GameObject presentPrefab;
    float presentDropShiftDistance = 1;

    float? timeSinceLastPresent = null;
    float timeBetweenPresents = 1.0f;
    bool wantsToDropPresent = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsToDropPresent = true;
        }

        timeSinceLastPresent += Time.deltaTime;

        if (wantsToDropPresent && (timeSinceLastPresent == null || timeSinceLastPresent > timeBetweenPresents))
        {
            Drop();
            wantsToDropPresent = false;
            timeSinceLastPresent = 0.0f;
        }
    }

    private void Drop()
    {
        if (presentPrefab != null)
        {
            var velocity = this.GetComponent<Velocity>().velocity;

            var present = Instantiate(presentPrefab);
            present.transform.position = transform.position + -transform.up * presentDropShiftDistance;
            present.GetComponent<Rigidbody>().velocity = transform.rotation * velocity;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudolfMovement : MonoBehaviour
{
    Vector3 initialLocalPosition;
    float randomOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialLocalPosition = transform.localPosition;
        randomOffset = Random.value * 3.141f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = initialLocalPosition + new Vector3(0, Mathf.Sin(randomOffset + Time.time * 8) * 0.1f, 0);
    }
}

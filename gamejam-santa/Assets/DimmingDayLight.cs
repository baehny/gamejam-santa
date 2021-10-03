using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmingDayLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameState.Instance != null)
            GameState.Instance.TimeIncreased += (sender, args) =>
            {
                var light = this.GetComponent<Light>();
                light.intensity -= 0.5f;
            };
    }

    // Update is called once per frame
    void Update()
    {

    }
}

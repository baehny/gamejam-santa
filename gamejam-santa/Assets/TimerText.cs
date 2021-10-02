using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.Instance != null)
        {
            GetComponent<Text>().text = TimeSpan.FromSeconds(GameState.Instance.Timer).ToString(@"mm\:ss\.fff");
        }
    }
}

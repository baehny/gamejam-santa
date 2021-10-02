using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance
    {
        get
        {
            return instance;
        }
    }

    public float Timer { get; private set; } = (float)new TimeSpan(0, 5, 0).TotalSeconds;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer < 0)
            Timer = 0.0f;
    }
}

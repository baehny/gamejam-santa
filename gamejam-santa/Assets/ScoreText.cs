using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.ScoreChanged += (sender, score) =>
        {
            GetComponent<Text>().text = $"Score: {score}";
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

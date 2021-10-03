using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScoreManager
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreManager();
            return instance;
        }
    }

    public int Score { get; private set; }

    public void IncreaseScore(int value)
    {
        Score += value;
        ScoreChanged?.Invoke(this, Score);
    }

    public event EventHandler<int> ScoreChanged;
}

public class Present : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.gameObject;
        if (other.TryGetComponent<PresentTargetComponent>(out var targetComponent))
        {
            ScoreManager.Instance.IncreaseScore(targetComponent.ScoreOnHit);
            GameObject.Destroy(this.gameObject);
        }
    }
}

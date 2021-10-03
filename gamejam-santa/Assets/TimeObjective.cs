using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjective : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player2>(out var player))
        {
            if (GameState.Instance != null)
            {
                GameState.Instance.AddTime(60);
            }
        }
    }
}

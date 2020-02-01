using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EnemiesCounter _enemiesCounter;
    private void OnEnable()
    {
        _enemiesCounter.EnemiesExpired += DisablePlayer;
    }

    private void OnDisable()
    {
        _enemiesCounter.EnemiesExpired -= DisablePlayer;
    }

    private void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
}

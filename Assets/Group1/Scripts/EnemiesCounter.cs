using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnemiesExpired;
    [SerializeField] private AttackChecker _attackChecker;
    private Object[] _enemies;
    private int _enemiesCount;

    public event UnityAction EnemiesExpired
    {
        add => _onEnemiesExpired.AddListener(value);
        remove => _onEnemiesExpired.RemoveListener(value);
    }

    private void OnEnable()
    {
        _attackChecker.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _attackChecker.Attacked += OnAttacked;
    }

    private void Start()
    {
        _enemies = FindObjectsOfType(typeof(Enemy));
        _enemiesCount = _enemies.Length;
    }

    private void OnAttacked()
    {
        _enemiesCount--;
        if (_enemiesCount == 0)
        {
            _onEnemiesExpired.Invoke();
        }
    }
}

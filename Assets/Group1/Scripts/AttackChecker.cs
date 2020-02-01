using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAttacked;

    public event UnityAction Attacked
    {
        add => _onAttacked.AddListener(value);
        remove => _onAttacked.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");

        if (collision.GetComponent<Enemy>())
        {
            Debug.Log("Attack");
            _onAttacked.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

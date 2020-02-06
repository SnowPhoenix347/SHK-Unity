using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _attacked;

    public event UnityAction Attacked
    {
        add => _attacked.AddListener(value);
        remove => _attacked.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");

        if (collision.GetComponent<Enemy>())
        {
            Debug.Log("Attack");
            _attacked.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

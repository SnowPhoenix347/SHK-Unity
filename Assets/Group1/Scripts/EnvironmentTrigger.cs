using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _bonusCollected;
    [SerializeField] private UnityEvent _attacking;

    public event UnityAction BonusCollected
    {
        add => _bonusCollected.AddListener(value);
        remove => _bonusCollected.RemoveListener(value);
    }

    public event UnityAction Attacking
    {
        add => _attacking.AddListener(value);
        remove => _attacking.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
        {
            _bonusCollected.Invoke();
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Enemy>())
        {
            _attacking.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

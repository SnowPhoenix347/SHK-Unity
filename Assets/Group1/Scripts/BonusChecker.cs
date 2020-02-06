using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _bonusCollected;

    public event UnityAction BonusCollected
    {
        add => _bonusCollected.AddListener(value);
        remove => _bonusCollected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
        {
            _bonusCollected.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

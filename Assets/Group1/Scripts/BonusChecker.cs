using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _onBonusCollected;

    public event UnityAction BonusCollected
    {
        add => _onBonusCollected.AddListener(value);
        remove => _onBonusCollected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
        {
            _onBonusCollected.Invoke();
            Destroy(collision.gameObject);
        }
    }
}

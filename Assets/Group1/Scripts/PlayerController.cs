using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BonusChecker _bonusChecker;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _bonusRatio = 1;
    [SerializeField] private float _bonusDuration = 2;

    private void OnEnable()
    {
        _bonusChecker.BonusCollected += UseBonus;
    }

    private void OnDisable()
    {
        _bonusChecker.BonusCollected += UseBonus;
    }

    private void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void UseBonus()
    {
        float defaultSpeed = _speed;
        _speed += defaultSpeed * _bonusRatio;
        StartCoroutine(SpeedToDefault(defaultSpeed));
    }

    private IEnumerator SpeedToDefault(float defaultSpeed)
    {
        _speed -= defaultSpeed * _bonusRatio;
        yield return new WaitForSeconds(_bonusDuration);
    }
}
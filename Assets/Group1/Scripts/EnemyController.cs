using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 Target;

    private void Update()
    {
        if (transform.position == Target) Target = Random.insideUnitCircle * 4;
        transform.position = Vector3.MoveTowards(transform.position, Target, 2 * Time.deltaTime);
    }
}
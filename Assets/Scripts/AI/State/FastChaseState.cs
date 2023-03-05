using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float MoveSpeed = 8f;
    [SerializeField] private float MaxDistance = 10f;
    [SerializeField] private float MinDistance = 5f;

    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            transform.LookAt(targetTransform);

            if (Vector2.Distance(transform.position, targetTransform.position) >= MinDistance)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
                {
                    isInAttackRange = true;
                }

            }
            return this;
        }
    }
}

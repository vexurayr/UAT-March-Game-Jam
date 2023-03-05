using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public FastChaseState fastChaseState;
    public bool isInSpeedupRange;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float MoveSpeed = 4f;
    [SerializeField] private float MaxDistance = 10f;
    [SerializeField] private float MinDistance = 5f;

    public override State RunCurrentState()
    {
        if (isInSpeedupRange)
        {
            return fastChaseState;
        }
        else
        {
            transform.LookAt(targetTransform);

            if (Vector2.Distance(transform.position, targetTransform.position) >= MinDistance)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
                {
                    isInSpeedupRange = true;
                }

            }
            return this;
        }
    }
}

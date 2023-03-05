using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public FastChaseState fastChaseState;
    public IdleState idleState;
    public bool isInSpeedupRange;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Character AI;
    [SerializeField] private float MoveSpeed = 1.3f;
    [SerializeField] private float MaxDistance = 20f;
    [SerializeField] private float MinDistance = 12f;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AI = GetComponentInParent<Character>();
    }

    public override State RunCurrentState()
    {
        if (targetTransform == null)
        {
            return idleState;
        }
        if (isInSpeedupRange)
        {
            return fastChaseState;
        }
        else
        {
            if (Vector2.Distance(AI.transform.position, targetTransform.position) >= MinDistance)
            {
                Vector3 direction = (targetTransform.position - transform.position);
                AI.transform.position += direction * MoveSpeed * Time.deltaTime;

                if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
                {
                    isInSpeedupRange = true;
                }
            }
            return this;
        }
    }
}

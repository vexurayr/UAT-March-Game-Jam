using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastChaseState : State
{
    public AttackState attackState;
    public IdleState idleState;
    public bool isInAttackRange;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Character AI;
    [SerializeField] private float MoveSpeed = 2f;
    [SerializeField] private float MaxDistance = 12f;
    [SerializeField] private float MinDistance = 4f;

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
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            if (Vector2.Distance(AI.transform.position, targetTransform.position) >= MinDistance)
            {
                Vector3 direction = (targetTransform.position - transform.position);
                AI.transform.position += direction * MoveSpeed * Time.deltaTime;

                if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
                {
                    isInAttackRange = true;
                }
            }
            return this;
        }
    }

    public void OnDisable()
    {
        targetTransform = null;
    }

    public void OnEnable()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
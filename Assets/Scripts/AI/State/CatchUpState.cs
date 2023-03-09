using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUpState : State
{
    public ChaseState chaseState;
    public bool isBackInRange;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Character AI;
    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private float MaxDistance = 200f;
    [SerializeField] private float MinDistance = 21f;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AI = GetComponentInParent<Character>();
    }

    public override State RunCurrentState()
    {
        if (isBackInRange)
        {
            return chaseState;
        }
        else
        {
            if (Vector2.Distance(AI.transform.position, targetTransform.position) >= MinDistance)
            {
                Vector3 direction = (targetTransform.position - transform.position);
                AI.transform.position += direction * MoveSpeed * Time.deltaTime;

                if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
                {
                    isBackInRange = true;
                }
            }
            return this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private Transform targetTransform;
    public IdleState idleState;
    [SerializeField] private Character AI;
    [SerializeField] private float MoveSpeed = 30f;
    [SerializeField] private float MaxDistance = 4f;
    [SerializeField] private float MinDistance = 0.01f;

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
        if (Vector2.Distance(AI.transform.position, targetTransform.position) >= MinDistance)
        {
            Vector3 direction = (targetTransform.position - transform.position);
            AI.transform.position += direction * MoveSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, targetTransform.position) <= MaxDistance)
            {
                //melee;
            }
            else
            {
                //melee;
            }
        }
        return this;
    }
}

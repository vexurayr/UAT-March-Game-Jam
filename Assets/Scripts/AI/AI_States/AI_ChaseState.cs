using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_ChaseState : AI_State
{
    public AI_AttackState attackState;
    public bool isInAttackRange;

    public override AI_State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}

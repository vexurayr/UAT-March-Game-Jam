using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_IdleState : AI_State
{
    public AI_ChaseState chaseState;
    public bool canSeePlayer;

    public override AI_State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}

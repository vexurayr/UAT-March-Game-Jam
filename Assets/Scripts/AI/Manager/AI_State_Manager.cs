using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_State_Manager : MonoBehaviour
{
    public AI_State currentState;

    // Update is called once per frame
    private void FixedUpdate()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        AI_State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(AI_State nextState)
    {

    }
}

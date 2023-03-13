using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusDeadState : IState
{
    AmogusStateMachine amogusStateMachine;

    public AmogusDeadState(AmogusStateMachine amogusStateMachine)
    {
        this.amogusStateMachine = amogusStateMachine;
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Dead");
        amogusStateMachine.PathFinder.enabled = false;
        amogusStateMachine.AmogusAnimationHandler.ChangeAnimationState("Dead");
        Object.Destroy(amogusStateMachine.gameObject, 5);
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {
        
    }
    
    public void Exit()
    {
        
    }
}

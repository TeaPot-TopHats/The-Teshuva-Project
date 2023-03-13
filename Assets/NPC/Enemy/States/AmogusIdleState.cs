using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusIdleState : IState
{
    AmogusStateMachine amogusStateMachine;

    public AmogusIdleState(AmogusStateMachine amogusStateMachine)
    {
        this.amogusStateMachine = amogusStateMachine;
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Idle");
        amogusStateMachine.PathFinder.enabled = false;
        amogusStateMachine.AmogusAnimationHandler.ChangeAnimationState("Idle");
        
    }

    public void Tick()
    {
        CheckPlayer();
    }
    
    public void FixedTick()
    {

    }

    public void Exit()
    {
        //amogusStateMachine.AmogusAnimationHandler.IdleOff();
    }

    void CheckPlayer()
    {
        Debug.Log("Check For player");
        Debug.Log(amogusStateMachine.Player != null);
        if (amogusStateMachine.Player != null)
            amogusStateMachine.ChangeState(amogusStateMachine.MoveState);
        else Debug.Log("Player not found");
    }
}

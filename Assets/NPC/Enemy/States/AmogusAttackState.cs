using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusAttackState : IState
{
    AmogusStateMachine amogusStateMachine;

    public AmogusAttackState(AmogusStateMachine amogusStateMachine)
    {
        this.amogusStateMachine = amogusStateMachine;
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Attack");
        amogusStateMachine.AmogusAnimationHandler.ChangeAnimationState("Attacking");
    }

    public void Tick()
    {
        
    }
    
    public void FixedTick()
    {

    } 

    public void Exit()
    {
        //amogusStateMachine.AmogusAnimationHandler.AttackOff();
    }

    public void LaunchAttack()
    {
        amogusStateMachine.atkCoolDown = amogusStateMachine.defaultAtkCoolDown;
        Debug.Log("Attack Launched");
        
        //do attack stuff
    }
    //NOTE TO SELF: Instantiate object that will act as area of effect for attacks
    //and handle whether the player is hit or not
    
    public void AttackEnded()
    {
        Debug.Log("Attack Over");
        amogusStateMachine.ChangeState(amogusStateMachine.IdleState);
    }

}

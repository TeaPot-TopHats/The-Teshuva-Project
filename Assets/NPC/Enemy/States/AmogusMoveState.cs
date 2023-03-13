using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusMoveState : IState
{
    AmogusStateMachine amogusStateMachine;
    AmogusSensor Sensor;

    public AmogusMoveState(AmogusStateMachine amogusStateMachine)
    {
        this.amogusStateMachine = amogusStateMachine;
        Sensor = new AmogusSensor(amogusStateMachine.AttackTransformer, amogusStateMachine.attackTransformerRadius, amogusStateMachine.PlayerLayer);
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Move");
        amogusStateMachine.PathFinder.enabled = true;
        amogusStateMachine.AmogusAnimationHandler.ChangeAnimationState("Moving");
    }

    public void Tick()
    {
        
        if (Sensor.CheckRange() && amogusStateMachine.atkCoolDown <= 0)
            amogusStateMachine.ChangeState(amogusStateMachine.AttackState);
        if (amogusStateMachine.atkCoolDown > 0)
            amogusStateMachine.atkCoolDown -= Time.deltaTime;
        if (amogusStateMachine.invincibility > 0)
            amogusStateMachine.atkCoolDown -= Time.deltaTime;
    }

    public void FixedTick()
    {

    }

    public void Exit()
    {
        amogusStateMachine.PathFinder.enabled = false;
    }

}

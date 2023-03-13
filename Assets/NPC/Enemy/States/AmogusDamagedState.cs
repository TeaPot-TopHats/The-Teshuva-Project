using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusDamagedState : IState
{
    AmogusStateMachine amogusStateMachine;

    public AmogusDamagedState(AmogusStateMachine amogusStateMachine)
    {
        this.amogusStateMachine = amogusStateMachine;
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Damaged");
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }

    public void FixedTick()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}

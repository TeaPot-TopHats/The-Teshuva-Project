using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{

    public IState CurrentState { get; private set; }
    public IState PreviousState;

    bool inTransition = false;

    public void ChangeState(IState newState)
    {
        if (CurrentState == newState || inTransition)
            return;

        ChangeStateRoutine(newState);
    }

    public void RevertState()
    {
        if (PreviousState != null)
            ChangeState(PreviousState);

    }

    void ChangeStateRoutine(IState newState)
    {
        inTransition = true;
        if (CurrentState != null)
            CurrentState.Exit();
        if (PreviousState != null)
            PreviousState = CurrentState;
        CurrentState = newState;
        if (CurrentState != null)
            CurrentState.Enter();
        inTransition = false;
    }

    public void Update()
    {
        if (CurrentState != null && !inTransition)
            CurrentState.Tick();
    }

    public void FixedUpdate()
    {
        if (CurrentState != null && !inTransition)
            CurrentState.FixedTick();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmogusAnimator
{
    public Animator animator;
    private string currentState;

    public AmogusAnimator(AmogusStateMachine stateMachine)
    {
        animator = stateMachine.AnimationComponent;
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        animator.Play(newState);
        currentState = newState;
    }

}

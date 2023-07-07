using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStateManager : BaseStateManager
{
    public Animator[] animators;
    public Collider2D[] blockingColliders;
    public Collider2D[] helpingColliders;

    public BaseState TargetOpenState;
    public BaseState TargetClosedState;

    public State InitialState;

    void Awake()
    {
        TargetOpenState = new TargetOpenState(this);
        TargetClosedState = new TargetClosedState(this);
    }

    public override BaseState GetInitialState()
    {
        if (InitialState == State.Open)
            return TargetOpenState;
        return TargetClosedState;
    }

    public void FlipState()
    {
        if (currentState == TargetOpenState)
            SwitchState(TargetClosedState);
        else
            SwitchState(TargetOpenState);
    }

}

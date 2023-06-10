using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStateManager : BaseStateManager, IInteractable
{
    public bool elastic;
    public Animator animator;
    public TargetStateManager target;
    [HideInInspector]
    public PlayerStateManager interactor;

    public BaseState LeverOpenState;
    public BaseState LeverOpenHeldState;
    public BaseState LeverClosedState;

    void Awake()
    {
        LeverOpenState = new LeverOpenState(this);
        LeverOpenHeldState = new LeverOpenHeldState(this);
        LeverClosedState = new LeverClosedState(this);
    }

    public void Interact(PlayerStateManager interactor)
    {
        this.interactor = interactor;
        ((IInteractable)currentState).Interact(interactor);
    }

    public override BaseState GetInitialState()
    {
        return LeverClosedState;
    }

}

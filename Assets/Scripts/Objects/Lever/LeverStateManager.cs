using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStateManager : BaseStateManager, IInteractable
{
    public Animator animator;
    public DoorStateManager door;

    public BaseState LeverOpenState;
    public BaseState LeverClosedState;

    void Awake()
    {
        LeverOpenState = new LeverOpenState(this);
        LeverClosedState = new LeverClosedState(this);
    }

    public void Interact(PlayerStateManager interactor)
    {
        ((IInteractable)currentState).Interact(interactor);
    }

    public override BaseState GetInitialState()
    {
        return LeverClosedState;
    }

}

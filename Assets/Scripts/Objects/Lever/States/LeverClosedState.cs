using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverClosedState : BaseState, IInteractable
{
    public GameObject UI { get; }

    public LeverClosedState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", false);
    }

    public void Interact(PlayerStateManager interactor)
    {
        if(((LeverStateManager)manager).elastic)
            ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverOpenHeldState);
        else
            ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverOpenState);
    }
}

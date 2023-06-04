using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverClosedState : BaseState, IInteractable
{
    public LeverClosedState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", false);
        ((LeverStateManager)manager).door.SwitchState(((LeverStateManager)manager).door.DoorClosedState);
    }

    public void Interact(PlayerStateManager interactor)
    {
        ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverOpenState);
    }
}

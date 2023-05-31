using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenState : BaseState, IInteractable
{
    public LeverOpenState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", true);
        ((LeverStateManager)manager).door.SwitchState(((LeverStateManager)manager).door.DoorOpenState);
    }

    public void Interact()
    {
        ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverClosedState);
    }
}

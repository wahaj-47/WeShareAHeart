using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenState : BaseState, IInteractable
{
    public LeverOpenState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", true);
        ((LeverStateManager)manager).target.SwitchState(((LeverStateManager)manager).target.TargetOpenState);
    }

    public void Interact(PlayerStateManager interactor)
    {
        ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverClosedState);
    }
}

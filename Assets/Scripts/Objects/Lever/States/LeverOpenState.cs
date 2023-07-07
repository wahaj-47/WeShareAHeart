using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenState : BaseState, IInteractable
{
    public GameObject UI { get; }

    public LeverOpenState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", true);
    }

    public void Interact(PlayerStateManager interactor)
    {
        ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverClosedState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenHeldState : BaseState
{
    public LeverOpenHeldState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", true);
    }

    public override void UpdateState()
    {
        if(!Input.GetButton("Fire" + ((LeverStateManager)manager).interactor.playerId) || ((LeverStateManager)manager).interactor.interactable == null)
        {
            foreach (TargetStateManager target in ((LeverStateManager)manager).targets)
            {
                target.FlipState();
            }

            ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverClosedState);
        }
    }

}

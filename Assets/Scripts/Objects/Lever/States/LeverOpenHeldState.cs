using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenHeldState : BaseState
{
    public LeverOpenHeldState(LeverStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((LeverStateManager)manager).animator.SetBool("Open", true);
        ((LeverStateManager)manager).target.SwitchState(((LeverStateManager)manager).target.TargetOpenState);
    }

    public override void UpdateState()
    {
        if(!Input.GetButton("Fire" + ((LeverStateManager)manager).interactor.playerId) || ((LeverStateManager)manager).interactor.interactable == null)
        {
            ((LeverStateManager)manager).SwitchState(((LeverStateManager)manager).LeverClosedState);
        }
    }

}

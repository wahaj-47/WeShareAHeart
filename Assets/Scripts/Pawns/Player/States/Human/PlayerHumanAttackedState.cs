using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanAttackedState : PlayerHumanBaseState
{
    public PlayerHumanAttackedState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Vector3 throwDirection = ((PlayerStateManager)manager).transform.up * 5;
        base.Fire(throwDirection);
    }

}

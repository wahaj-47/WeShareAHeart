using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenState : BaseState
{
    public DoorOpenState(DoorStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((DoorStateManager)manager).animator.SetBool("Open", true);
        ((DoorStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Default");
        ((DoorStateManager)manager).box.isTrigger = true;
    }
}

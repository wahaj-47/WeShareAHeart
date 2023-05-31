using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosedState : BaseState
{
    public DoorClosedState(DoorStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((DoorStateManager)manager).animator.SetBool("Open", false);
        ((DoorStateManager)manager).box.isTrigger = false;
    }

}

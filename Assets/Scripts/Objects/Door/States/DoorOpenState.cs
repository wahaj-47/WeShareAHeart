using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenState : BaseState
{
    public DoorOpenState(DoorStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Open door");
        ((DoorStateManager)manager).animator.SetBool("Open", true);
        ((DoorStateManager)manager).box.isTrigger = true;
    }
}

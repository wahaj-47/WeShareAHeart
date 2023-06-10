using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClosedState : BaseState
{
    public TargetClosedState(TargetStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((TargetStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Object");

        foreach (Animator animator in ((TargetStateManager)manager).animators)
        {
            animator.SetBool("Open", false);
        }
        foreach (Collider2D collider in ((TargetStateManager)manager).blockingColliders)
        {
            collider.isTrigger = false;
        }
        foreach (Collider2D collider in ((TargetStateManager)manager).helpingColliders)
        {
            collider.isTrigger = true;
        }
    }
}

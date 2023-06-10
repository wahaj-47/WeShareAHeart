using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOpenState : BaseState
{
    public TargetOpenState(TargetStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((TargetStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Default");

        foreach(Animator animator in ((TargetStateManager)manager).animators)
        {
            animator.SetBool("Open", true);
        }
        foreach(Collider2D collider in ((TargetStateManager)manager).blockingColliders)
        {
            collider.isTrigger = true;
        }
        foreach (Collider2D collider in ((TargetStateManager)manager).helpingColliders)
        {
            collider.isTrigger = false;
        }
    }
}

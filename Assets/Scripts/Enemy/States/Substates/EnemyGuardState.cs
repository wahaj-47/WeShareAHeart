using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : EnemyBaseState
{

    public EnemyGuardState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Looking for target");
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0.0f);
        ((EnemyStateManager)manager).target = null;
    }

    public override void UpdateState()
    {
        if (CanSeePlayer())
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
        }
    }

}

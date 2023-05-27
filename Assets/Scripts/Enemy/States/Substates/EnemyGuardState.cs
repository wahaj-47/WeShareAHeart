using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : EnemyBaseState
{

    public EnemyGuardState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0.0f);
        ((EnemyStateManager)manager).target = null;
    }

    public override void UpdateState()
    {
        if (CanSee("Human"))
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
        }
    }

}

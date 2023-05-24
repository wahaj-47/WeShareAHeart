using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{

    public EnemyAttackState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((EnemyStateManager)manager).animator.SetTrigger("Jump");
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0);
        ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
    }
}

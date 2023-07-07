using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : EnemyBaseState
{

    public EnemyGuardState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();

        ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0.0f);
        ((EnemyStateManager)manager).target = null;
        if (((EnemyStateManager)manager).Patrol)
        {
            ((EnemyStateManager)manager).StartCoroutine("DoCoroutine", this.StartPatrol());
        }
    }

    public override void UpdateState()
    {
        if (CanSee("Human") || CanSee("Heart"))
        {
            ((EnemyStateManager)manager).StopCoroutine("DoCoroutine");
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
        }
    }

    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(2f);
        ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyPatrolState);
    }

}

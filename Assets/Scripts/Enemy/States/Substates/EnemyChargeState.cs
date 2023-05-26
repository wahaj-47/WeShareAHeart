using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyBaseState
{
    private Vector2 direction;
    private float moveSpeed = 3f;
    public EnemyChargeState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        // Switch to running animation
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);   
    }

    public override void FixedUpdateState()
    {
        // Move towards the target
        ((EnemyStateManager)manager).rb.MovePosition(((EnemyStateManager)manager).rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public override void UpdateState()
    {
        if (CanSeePlayer())
        {
            Vector2 distance = ((EnemyStateManager)manager).target.position - ((EnemyStateManager)manager).transform.position;
            direction = distance.normalized;
            if(distance.magnitude < 1f)
            {
                ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyAttackState);
            }
        } 
        else 
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }
    }

}

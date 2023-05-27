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

        if (CanSee("Human"))
        {
            Vector2 distance = ((EnemyStateManager)manager).target.position - ((EnemyStateManager)manager).transform.position;
            direction = distance.normalized;

            if (distance.magnitude < 1f)
            {
                ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyAttackState);
            }
        }
        else
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }

        // Move towards the target
        ((EnemyStateManager)manager).rb.MovePosition(((EnemyStateManager)manager).rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public override void UpdateState()
    {
        if (direction.x > 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (direction.x < 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

}
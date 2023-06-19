using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyBaseState
{
    private Vector2 direction;
    private float moveSpeed = 25f;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = 0.05f;

    public EnemyChargeState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        // Switch to running animation
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);   
    }

    public override void FixedUpdateState()
    {

        if (!CanSee("Human") && !CanSee("Heart"))
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }

        if (((EnemyStateManager)manager).target)
        {
            Vector2 distance = ((EnemyStateManager)manager).target.position - ((EnemyStateManager)manager).transform.position;
            direction = distance.normalized;
            direction.y = 0;

            if (((EnemyStateManager)manager).target.tag == "Human")
            {   
                if (distance.magnitude < 1f)
                {
                    ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyAttackState);
                }
            }
        }

        // Move towards the target
        if (((EnemyStateManager)manager).utils.IsGrounded())
        {
            Vector3 targetVelocity = direction * moveSpeed * Time.fixedDeltaTime * 10f;
            ((EnemyStateManager)manager).rb.velocity = Vector3.SmoothDamp(((EnemyStateManager)manager).rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        
    }

    public override void UpdateState()
    {
        if (direction.x < 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (direction.x > 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

}

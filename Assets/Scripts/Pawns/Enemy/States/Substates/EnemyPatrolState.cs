using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private float moveSpeed = 8f;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = 0.0f;

    public EnemyPatrolState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();

        ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);
    }

    public override void UpdateState()
    {

        if (CanSee("Human") || CanSee("Heart"))
        {
            ((EnemyStateManager)manager).StopCoroutine("DoCoroutine");
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
        }

        Vector3 targetVelocity = (Vector2)(((EnemyStateManager)manager).transform.right) * moveSpeed * Time.fixedDeltaTime * 10f;
        ((EnemyStateManager)manager).rb.velocity = Vector3.SmoothDamp(((EnemyStateManager)manager).rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    } 

    public override void OnCollisionEnter2D(Collision2D other)
    {

        base.OnCollisionEnter2D(other);
        
        if(other.collider.tag != "Ground")
        {
            ((EnemyStateManager)manager).transform.RotateAround(((EnemyStateManager)manager).transform.position, ((EnemyStateManager)manager).transform.up, 180);

            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }
    
    }

}

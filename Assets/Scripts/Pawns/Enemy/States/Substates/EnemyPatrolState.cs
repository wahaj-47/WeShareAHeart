using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private int moveSpeed = 1;

    public EnemyPatrolState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);
    }

    public override void UpdateState()
    {
        if (CanSee("Human") || CanSee("Heart"))
        {
            ((EnemyStateManager)manager).StopCoroutine("DoCoroutine");
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
        }

        ((EnemyStateManager)manager).rb.MovePosition(((EnemyStateManager)manager).rb.position + (Vector2)(((EnemyStateManager)manager).transform.right) * moveSpeed * Time.fixedDeltaTime);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {

        base.OnCollisionEnter2D(other);

        if(other.collider.tag == "Object")
        {
            ((EnemyStateManager)manager).transform.RotateAround(((EnemyStateManager)manager).transform.position, ((EnemyStateManager)manager).transform.up, 180);

            ((EnemyStateManager)manager).StartCoroutine("DoCoroutine", this.Patrol());

            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }

    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(2f);
        ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyPatrolState);
    }
}

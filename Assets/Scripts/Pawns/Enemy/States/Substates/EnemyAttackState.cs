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
        Vector2 direction = ((EnemyStateManager)manager).transform.right;
        direction.y = 0.5f;
        ((EnemyStateManager)manager).rb.AddForce(direction * 5f, ForceMode2D.Impulse);

        ((EnemyStateManager)manager).StartCoroutine("DoCoroutine", this.CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
    }
}

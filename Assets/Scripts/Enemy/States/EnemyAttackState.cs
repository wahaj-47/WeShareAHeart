using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    public Vector2 movement;
    public EnemyAttackState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Target locked. Commencing attack");
        movement = (((EnemyStateManager)manager).transform.position - ((EnemyStateManager)manager).target.transform.position).normalized;
    }

    public override void UpdateState()
    {
        Debug.Log(movement);
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Human")
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }
    }

}

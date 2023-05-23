using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : BaseState
{

    public EnemyGuardState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Looking for target");
        ((EnemyStateManager)manager).target = null;
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Human")
        {
            ((EnemyStateManager)manager).target = other.transform;
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyAttackState);
        }
    }
}

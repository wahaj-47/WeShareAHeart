using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : BaseState
{

    public EnemyBaseState(EnemyStateManager manager) : base(manager) { }

    public override void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log(other.collider.name);
        if(other.collider.tag == "Human")
        {
            PlayerStateManager manager = other.collider.gameObject.GetComponent<PlayerStateManager>();
            manager.SwitchState(manager.HumanAttackedState);
        }
    }

    protected bool CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(((EnemyStateManager)manager).transform.position, ((EnemyStateManager)manager).transform.right, -5, ~LayerMask.GetMask("Ghost", "Enemy"));

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Human")
            {
                ((EnemyStateManager)manager).target = hit.collider.gameObject.transform;
                return true;
            }
        }

        ((EnemyStateManager)manager).target = null;
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : BaseState
{

    public EnemyBaseState(EnemyStateManager manager) : base(manager) { }

    public override void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.collider.tag == "Heart")
        {
            GameObject.Destroy(other.collider.gameObject);
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyDevourState);
        }

        if (other.collider.tag == "Human")
        {
            PlayerStateManager manager = other.collider.gameObject.GetComponent<PlayerStateManager>();
            manager.SwitchState(manager.HumanAttackedState);
        }
    }    

    protected bool CanSee(string tag)
    {
        RaycastHit2D hit = Physics2D.BoxCast(((EnemyStateManager)manager).transform.position, ((EnemyStateManager)manager).box.size, 0, ((EnemyStateManager)manager).transform.right, 5, ~LayerMask.GetMask("Default", "Ghost", "Enemy"));

        if (hit.collider != null)
        {
            if (hit.collider.tag == tag)
            {
                ((EnemyStateManager)manager).target = hit.collider.gameObject.transform;
                return true;
            }
        }

        ((EnemyStateManager)manager).target = null;
        return false;
    }
}

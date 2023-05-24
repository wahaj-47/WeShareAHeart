using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : BaseState
{

    public EnemyGuardState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Looking for target");
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0.0f);
        ((EnemyStateManager)manager).target = null;
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Human")
        {
            Vector2 distance =  other.transform.position - ((EnemyStateManager)manager).transform.position;
            float magnitude = distance.magnitude;
            Vector2 direction = distance.normalized;


            RaycastHit2D hit = Physics2D.Raycast(((EnemyStateManager)manager).transform.position, direction, magnitude);

            if (hit.collider != null)
            {
                if(hit.collider.tag == "Human")
                {
                    ((EnemyStateManager)manager).target = other.transform;
                    ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyChargeState);
                }
            }

        }
    }
}

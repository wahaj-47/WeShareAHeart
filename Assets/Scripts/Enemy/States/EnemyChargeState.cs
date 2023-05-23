using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : BaseState
{
    private Vector2 direction;
    private float magnitude;
    private float moveSpeed = 3f;
    public EnemyChargeState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        Debug.Log("Target locked. Commencing attack");
        ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);
        Vector2 distance = (((EnemyStateManager)manager).target.transform.position - ((EnemyStateManager)manager).transform.position);
        direction = distance.normalized;
        magnitude = distance.magnitude;
    }

    public override void FixedUpdateState()
    {
        ((EnemyStateManager)manager).rb.MovePosition(((EnemyStateManager)manager).rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Human")
        {
            Vector2 distance = (((EnemyStateManager)manager).target.transform.position - ((EnemyStateManager)manager).transform.position);
            direction = distance.normalized;
            magnitude = distance.magnitude;
        } else if(other.tag == "Ghost")
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Human")
        {
            ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
        }
    }

}

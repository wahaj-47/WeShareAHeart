using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPossessedState : BaseState
{
    private Vector2 movement;
    private float moveSpeed = 3f;

    public EnemyPossessedState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        DOTween.To(() => ((EnemyStateManager)manager).sprite.color, x => ((EnemyStateManager)manager).sprite.color = x, new Color(255, 255, 0, 1), 0.5f);
        ((EnemyStateManager)manager).controller.SwitchState(((EnemyStateManager)manager).controller.GhostMasterState);
        ((EnemyStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Ignore Player");
    }

    public override void UpdateState()
    {
        ((EnemyStateManager)manager).controller.transform.position = ((EnemyStateManager)manager).transform.position;

        movement.x = Input.GetAxisRaw("Player" + ((EnemyStateManager)manager).controller.playerId + "Horizontal");

        if(movement.x != 0)
        {
            ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);
        }
        else
        {
            ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0);
        }

        if (movement.x < 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (movement.x > 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

    public override void FixedUpdateState()
    {
        ((EnemyStateManager)manager).rb.MovePosition(((EnemyStateManager)manager).rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}

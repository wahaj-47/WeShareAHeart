using UnityEngine;
using DG.Tweening;

public class PlayerHumanRoamState : PlayerHumanBaseState
{

    public PlayerHumanRoamState(PlayerStateManager manager) : base(manager) { }

    public override void UpdateState()
    {
        base.UpdateState();

        ((PlayerStateManager)manager).animator.SetBool("isMoving", base.movement.x != 0);

        if (Input.GetButtonDown("Fire" + ((PlayerStateManager)manager).playerId))
        {
            if (((PlayerStateManager)manager).interactable != null)
            {
                ((PlayerStateManager)manager).interactable.Interact((PlayerStateManager)manager);
            }
            else
            {
                ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).HumanAimState);
            }
        }

        if(movement.x != 0)
        {
            float dot = CheckSlope();

            if (dot < 0) DOTween.To(() => ((PlayerStateManager)manager).moveSpeed, x => ((PlayerStateManager)manager).moveSpeed = x, 100f, 0.05f);
            else if (dot > 0) DOTween.To(() => ((PlayerStateManager)manager).moveSpeed, x => ((PlayerStateManager)manager).moveSpeed = x, 15f, 0.05f);
            else DOTween.To(() => ((PlayerStateManager)manager).moveSpeed, x => ((PlayerStateManager)manager).moveSpeed = x, 30f, 0.1f);
        }
        else ((PlayerStateManager)manager).moveSpeed = 30f;
    }

    private float CheckSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(((PlayerStateManager)manager).GroundCheck.transform.position, -((PlayerStateManager)manager).GroundCheck.transform.up, 5f, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return Vector3.Dot(hit.normal, ((PlayerStateManager)manager).transform.right);
        }

        return 0f;
    }

}

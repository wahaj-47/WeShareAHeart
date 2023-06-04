using UnityEngine;

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

    }

}

using UnityEngine;

public class PlayerHumanInteractState : PlayerHumanBaseState
{

    public PlayerHumanInteractState(PlayerStateManager manager) : base(manager) { }

    public override void UpdateState()
    {
        base.UpdateState();

        ((PlayerStateManager)manager).animator.SetBool("isMoving", base.movement.x != 0);

        if (Input.GetButtonDown("Fire" + ((PlayerStateManager)manager).playerId))
        {
            ((PlayerStateManager)manager).interactable.Interact();
        }

    }

}

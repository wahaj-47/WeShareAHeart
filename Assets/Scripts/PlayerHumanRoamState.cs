using UnityEngine;

public class PlayerHumanRoamState : PlayerHumanBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        base.UpdateState(player);

        player.animator.SetBool("isMoving", base.movement.x != 0);

        if (Input.GetButtonDown("Fire" + player.playerId))
        {
            player.SwitchState(player.HumanAimState);
        }

    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        base.FixedUpdateState(player);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D other)
    {
        base.OnCollisionEnter2D(player, other);
    }

}

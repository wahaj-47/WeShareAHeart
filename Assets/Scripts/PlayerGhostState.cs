using UnityEngine;

public class PlayerGhostState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);

        player.gameObject.tag = "Ghost";
        player.rb.gravityScale = 0f;
        player.gameObject.layer = LayerMask.NameToLayer("Ghost");
        player.animator.SetBool("hasHeart", false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        base.UpdateState(player);
        base.movement.y = Input.GetAxisRaw("Player" + player.playerId + "Vertical");
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        base.FixedUpdateState(player);
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {
        base.OnCollisionEnter(player);
    }

}

using UnityEngine;

public class PlayerHumanBaseState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);

        player.gameObject.tag = "Human";
        player.rb.gravityScale = 9.8f;
        player.gameObject.layer = LayerMask.NameToLayer("Human");
        player.animator.SetBool("hasHeart", true);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        base.UpdateState(player);
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

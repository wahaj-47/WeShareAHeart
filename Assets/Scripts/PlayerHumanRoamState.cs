using UnityEngine;

public class PlayerHumanRoamState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);

        player.gameObject.tag = "Human";
        player.rb.gravityScale = 9.8f;
        player.gameObject.layer = LayerMask.NameToLayer("Human");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        base.UpdateState(player);

        if (Input.GetButtonDown("Fire" + player.playerId))
        {
            player.SwitchState(player.HumanAimState);
        }

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

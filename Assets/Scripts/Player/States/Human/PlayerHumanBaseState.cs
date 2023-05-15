using UnityEngine;

public class PlayerHumanBaseState : PlayerBaseState
{

    public PlayerHumanBaseState(PlayerStateManager manager) : base(manager){}

    public override void EnterState()
    {
        base.EnterState();

        ((PlayerStateManager)manager).gameObject.tag = "Human";
        ((PlayerStateManager)manager).rb.gravityScale = 9.8f;
        ((PlayerStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Human");
        ((PlayerStateManager)manager).animator.SetBool("hasHeart", true);
    }

}

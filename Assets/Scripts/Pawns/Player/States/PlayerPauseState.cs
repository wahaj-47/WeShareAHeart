using UnityEngine;

public class PlayerPauseState : BaseState
{
    public PlayerPauseState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();
        ((PlayerStateManager)manager).rb.velocity = Vector2.zero;
        ((PlayerStateManager)manager).animator.SetBool("isMoving", false);
    }

}

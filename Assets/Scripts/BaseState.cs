using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void FixedUpdateState(PlayerStateManager player);
    public abstract void OnCollisionEnter2D(PlayerStateManager player, Collision2D other);
}

using UnityEngine;

public class PlayerBaseState : BaseState
{
    public Vector2 movement;
    public float moveSpeed = 3f;

    public override void EnterState(PlayerStateManager player){}

    public override void UpdateState(PlayerStateManager player)
    {
        movement.x = Input.GetAxisRaw("Player" + player.playerId + "Horizontal");

        player.animator.SetBool("isMoving", movement.x != 0);

        if (movement.x < 0)
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (movement.x > 0)
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        player.rb.MovePosition(player.rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public override void OnCollisionEnter2D(PlayerStateManager player, Collision2D other){}
}

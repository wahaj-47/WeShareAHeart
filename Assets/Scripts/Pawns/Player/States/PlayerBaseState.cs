using UnityEngine;

public class PlayerBaseState : BaseState
{
    public Vector2 movement;
    private float moveSpeed = 3f;

    public PlayerBaseState(PlayerStateManager manager) : base(manager){}

    public override void UpdateState()
    {
        movement.x = Input.GetAxisRaw("Player" + ((PlayerStateManager)manager).playerId + "Horizontal");

        if (movement.x < 0)
        {
            ((PlayerStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (movement.x > 0)
        {
            ((PlayerStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

    public override void FixedUpdateState()
    {
        ((PlayerStateManager)manager).rb.MovePosition(((PlayerStateManager)manager).rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            ((PlayerStateManager)manager).interactable = interactable;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (((PlayerStateManager)manager).interactable != null)
        {
            ((PlayerStateManager)manager).interactable = null;
        }
    }

}

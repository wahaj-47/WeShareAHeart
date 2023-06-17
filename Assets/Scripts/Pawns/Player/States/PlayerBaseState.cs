using UnityEngine;

public class PlayerBaseState : BaseState
{
    public Vector2 movement = new Vector2(0,0);
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = 0.05f;

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
        Vector3 targetVelocity = movement * ((PlayerStateManager)manager).moveSpeed * Time.fixedDeltaTime * 10f;
        ((PlayerStateManager)manager).rb.velocity = Vector3.SmoothDamp(((PlayerStateManager)manager).rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
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

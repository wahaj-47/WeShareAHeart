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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if(interactable != null)
        {
            ((PlayerStateManager)manager).interactable = interactable;
            ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).HumanInteractState);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (((PlayerStateManager)manager).interactable != null)
        {
            ((PlayerStateManager)manager).interactable = null;
            ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).HumanRoamState);
        }
    }

    protected void Fire(Vector3 throwDirection)
    {

        // Switch to roaming
        ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).GhostState);

        // Spawn the heart prefab
        GameObject heart = GameObject.Instantiate(((PlayerStateManager)manager).HeartPrefab, ((PlayerStateManager)manager).ThrowPoint.transform.position, Quaternion.identity);

        heart.GetComponent<Spawner>().playerId = ((PlayerStateManager)manager).playerId;

        // Add impulse to the prefab
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        heartRb.AddForce(throwDirection, ForceMode2D.Impulse);

        // Hide the trajectory
        for (int i = 0; i < ((PlayerStateManager)manager).Points.Length; i++)
        {
            ((PlayerStateManager)manager).Points[i].SetActive(false);
        }

        // Play throwing animation
        ((PlayerStateManager)manager).animator.SetBool("throwing", true);

        ((PlayerStateManager)manager).animator.SetBool("turningHuman", false);

    }

}

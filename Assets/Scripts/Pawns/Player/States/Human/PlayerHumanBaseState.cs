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
        ((PlayerStateManager)manager).capsule.isTrigger = false;
        ((PlayerStateManager)manager).moveSpeed = 25f;

        StateManager.instance.StopDeathTimer();
    }

    protected void Fire(Vector3 throwDirection)
    {

        // Switch to ghost
        ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).GhostRoamState);

        // Spawn the heart prefab
        GameObject heart = GameObject.Instantiate(((PlayerStateManager)manager).HeartPrefab, ((PlayerStateManager)manager).ThrowPoint.transform.position, Quaternion.identity);

        heart.GetComponent<Spawner>().playerId = ((PlayerStateManager)manager).playerId;

        // Add impulse to the prefab
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        heartRb.AddForce(throwDirection, ForceMode2D.Impulse);

        HideTrajectory();

        // Play throwing animation
        ((PlayerStateManager)manager).animator.SetBool("throwing", true);

        ((PlayerStateManager)manager).animator.SetBool("turningHuman", false);

        StateManager.instance.StartDeathTimer();
    }

    protected void HideTrajectory()
    {
        // Hide the trajectory
        for (int i = 0; i < ((PlayerStateManager)manager).Points.Length; i++)
        {
            ((PlayerStateManager)manager).Points[i].SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanAttackedState : BaseState
{
    public PlayerHumanAttackedState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();

        ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).GhostState);

        // Spawn the heart prefab
        GameObject heart = GameObject.Instantiate(((PlayerStateManager)manager).HeartPrefab, ((PlayerStateManager)manager).ThrowPoint.transform.position, Quaternion.identity);

        heart.GetComponent<Spawner>().playerId = ((PlayerStateManager)manager).playerId;

        // Add impulse to the prefab
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        Vector3 throwDirection = ((PlayerStateManager)manager).transform.right * ((PlayerStateManager)manager).range / 2;

        heartRb.AddForce(throwDirection, ForceMode2D.Impulse);

        // Play throwing animation
        ((PlayerStateManager)manager).animator.SetBool("throwing", true);

        ((PlayerStateManager)manager).animator.SetBool("turningHuman", false);


    }

}

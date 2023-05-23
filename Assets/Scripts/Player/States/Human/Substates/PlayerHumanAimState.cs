using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanAimState : PlayerHumanBaseState
{
    private Vector3 throwDirection = new Vector3(0,0,0);
    private float incline = 5.0f;
    private float lift = 0.0f;

    public PlayerHumanAimState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();

        // Back to idle animation
        ((PlayerStateManager)manager).animator.SetBool("isMoving", false);

    }

    public override void UpdateState()
    {
        base.UpdateState();

        lift = Input.GetAxisRaw("Player" + ((PlayerStateManager)manager).playerId + "Vertical");

        if (Input.GetButtonDown("Fire" + ((PlayerStateManager)manager).playerId))
        {
            Fire();
        }

    }

    public override void FixedUpdateState()
    {
        float potentialIncline = incline + ((PlayerStateManager)manager).aimSpeed * lift * Time.fixedDeltaTime;
        
        if (potentialIncline > ((PlayerStateManager)manager).minIncline && potentialIncline < ((PlayerStateManager)manager).maxIncline)
        {
            incline = potentialIncline;
            CalculateTrajectory();
        }
    }

    void CalculateTrajectory()
    {
        for (int i = 0; i < ((PlayerStateManager)manager).Points.Length; i++)
        {
            ((PlayerStateManager)manager).Points[i].transform.position = CalculatePosition(i * 0.05f);
            ((PlayerStateManager)manager).Points[i].SetActive(true);
        }
    }

    Vector2 CalculatePosition(float t)
    {
        throwDirection = ((PlayerStateManager)manager).transform.right * ((PlayerStateManager)manager).range;
        throwDirection.y = incline;

        Vector2 position = (Vector2)(((PlayerStateManager)manager).transform.position + throwDirection * t) + 0.5f * Physics2D.gravity * (t * t);

        return position;
    }

    void Fire()
    {
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


        // Switch to roaming
        ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).GhostState);
    }
}

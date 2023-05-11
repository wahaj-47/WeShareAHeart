using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHumanAimState : PlayerHumanBaseState
{
    private Vector3 throwDirection = new Vector3(0,0,0);
    private float incline = 5.0f;

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);

        // Back to idle animation
        player.animator.SetBool("isMoving", false);

    }

    public override void UpdateState(PlayerStateManager player)
    {

        if (Input.GetButtonDown("Fire" + player.playerId))
        {
            Fire(player);
        }

    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        float direction = player.transform.rotation == Quaternion.Euler(new Vector3(0f, 0f, 0f)) ? -1 : 1;
        float potentialIncline = incline + direction * player.aimSpeed * movement.x * Time.fixedDeltaTime;
        
        if (potentialIncline > player.minIncline && potentialIncline < player.maxIncline)
        {
            incline = potentialIncline;
            CalculateTrajectory(player);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {
        base.OnCollisionEnter(player);
    }

    void CalculateTrajectory(PlayerStateManager player)
    {
        for (int i = 0; i < player.Points.Length; i++)
        {
            player.Points[i].transform.position = CalculatePosition(player, i * 0.05f);
            player.Points[i].SetActive(true);
        }
    }

    Vector2 CalculatePosition(PlayerStateManager player, float t)
    {
        throwDirection = player.transform.right * player.range;
        throwDirection.y = incline;

        Vector2 position = (Vector2)(player.transform.position + throwDirection * t) + 0.5f * Physics2D.gravity * (t * t);

        return position;
    }

    void Fire(PlayerStateManager player)
    {
        // Spawn the heart prefab
        GameObject heart = GameObject.Instantiate(player.HeartPrefab, player.ThrowPoint.transform.position, Quaternion.identity);

        // Add impulse to the prefab
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        heartRb.AddForce(throwDirection, ForceMode2D.Impulse);

        // Hide the trajectory
        for (int i = 0; i < player.Points.Length; i++)
        {
            player.Points[i].SetActive(false);
        }

        // Play throwing animation
        player.animator.SetBool("throwing", true);

        // Switch to roaming
        player.SwitchState(player.GhostState);
    }
}

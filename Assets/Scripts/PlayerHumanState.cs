using UnityEngine;

public class PlayerHumanState : PlayerBaseState
{
    private bool isAiming;

    public override void EnterState(PlayerStateManager player)
    {
        base.EnterState(player);

        player.gameObject.tag = "Human";
        player.rb.gravityScale = 9.8f;
        player.gameObject.layer = LayerMask.NameToLayer("Human");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        base.UpdateState(player);

        if (Input.GetButton("Fire" + player.playerId))
        {
            isAiming = true;
        }

        if(isAiming)
        {
            CalculateTrajectory(player);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        base.FixedUpdateState(player);
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {
        base.OnCollisionEnter(player);
    }

    void CalculateTrajectory(PlayerStateManager player)
    {
        for (int i = 0; i < player.Points.Length; i++)
        {
            player.Points[i].transform.position = CalculatePosition(player, i * 0.1f);
            player.Points[i].SetActive(true);
        }
    }

    Vector2 CalculatePosition(PlayerStateManager player, float t)
    {
        float incline = Mathf.PingPong(Time.time * player.aimSpeed, player.maxIncline);
        Vector3 direction = player.transform.right;
        direction.y = incline;

        Vector2 position = (Vector2)(player.transform.position + direction.normalized * player.range * t) + 0.5f * Physics2D.gravity * (t * t);

        return position;
    }
}

using UnityEngine;

public class PlayerHumanState : PlayerBaseState
{
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

        if (Input.GetButtonDown("Fire" + player.playerId))
        {
            Aim(player);
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

    void Aim(PlayerStateManager player)
    {
        int steps = 25;
        Vector2 startPosition = player.transform.position;
        Vector2 endPosition = startPosition + new Vector2((player.transform.right * player.range).x, player.incline);

        Vector2 velocity = startPosition - endPosition;

        Vector3[] plots = new Vector3[steps];
        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccelaration = Physics2D.gravity * player.rb.gravityScale * timestep * timestep;

        float drag = 1f - timestep * player.rb.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccelaration;
            moveStep *= drag;
            startPosition += moveStep;
            plots[i] = startPosition;
        }

        player.lr.SetPositions(plots);
    }
}

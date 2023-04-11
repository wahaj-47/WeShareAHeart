using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public int playerId = 1;
    public Rigidbody2D rb;
    public LineRenderer lr;
    public Animator animator;
    public float range = 5.0f;
    public float incline = 5.0f;

    PlayerBaseState currentState;
    PlayerHumanState HumanState = new PlayerHumanState();
    PlayerGhostState GhostState = new PlayerGhostState();

    // Start is called before the first frame update
    void Start()
    {
        if (playerId == 1)
            currentState = HumanState;
        else
            currentState = GhostState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }
}

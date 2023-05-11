using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public int playerId = 1;
    public Rigidbody2D rb;
    public Animator animator;

    public float range = 3f;
    public float minIncline = 0f;
    public float maxIncline = 7f;
    public float aimSpeed = 5f;

    public GameObject HeartPrefab;
    public GameObject PointPrefab;
    public GameObject ThrowPoint;

    public int numberOfPoints = 10;
    public GameObject[] Points;
    
    public PlayerBaseState currentState;
    public PlayerBaseState HumanRoamState = new PlayerHumanRoamState();
    public PlayerBaseState HumanAimState = new PlayerHumanAimState();
    public PlayerBaseState GhostState = new PlayerGhostState();

    // Start is called before the first frame update
    void Start()
    {
        if (playerId == 1)
            currentState = HumanRoamState;
        else
            currentState = GhostState;

        currentState.EnterState(this);

        Points = new GameObject[numberOfPoints];

        for(int i=0; i<numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Points[i].SetActive(false);
        }
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

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}

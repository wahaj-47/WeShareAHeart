using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public int playerId = 1;
    public Rigidbody2D rb;
    public Animator animator;

    public float range = 10f;
    public float maxIncline = 10f;
    public float aimSpeed = 0.5f;

    public GameObject HeartPrefab;
    public GameObject PointPrefab;

    public int numberOfPoints = 10;
    public GameObject[] Points;
    
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
}

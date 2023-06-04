using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseStateManager
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
    public CapsuleCollider2D capsule;

    public int numberOfPoints = 10;
    public GameObject[] Points;

    public BaseState HumanRoamState;
    public BaseState HumanAimState;
    public BaseState HumanAttackedState;
    public BaseState GhostRoamState;
    public BaseState GhostMasterState;

    public IInteractable interactable;

    void Awake()
    {
        HumanRoamState = new PlayerHumanRoamState(this);
        HumanAimState = new PlayerHumanAimState(this);
        HumanAttackedState = new PlayerHumanAttackedState(this);
        GhostRoamState = new PlayerGhostRoamState(this);
        GhostMasterState = new PlayerGhostMasterState(this);
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Points = new GameObject[numberOfPoints];

        for(int i=0; i<numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Points[i].SetActive(false);
        }
    }

    public override BaseState GetInitialState()
    {
        if (playerId == 1)
            return HumanRoamState;
        else
            return GhostRoamState;
    }

}

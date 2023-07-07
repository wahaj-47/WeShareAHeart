using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : BaseStateManager, IInteractable
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject heart;

    public bool Patrol;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public BoxCollider2D box;

    [HideInInspector]
    public PlayerStateManager controller;

    [HideInInspector] 
    public MovementUtils utils;

    [field: SerializeField]
    public GameObject UI { get; set; }

    public BaseState EnemyGuardState;
    public BaseState EnemyPatrolState;
    public BaseState EnemyChargeState;
    public BaseState EnemyAttackState;
    public BaseState EnemyDevourState;
    public BaseState EnemyPossessedState;

    void Awake()
    {
        EnemyGuardState = new EnemyGuardState(this);
        EnemyPatrolState = new EnemyPatrolState(this);
        EnemyChargeState = new EnemyChargeState(this);
        EnemyAttackState = new EnemyAttackState(this);
        EnemyDevourState = new EnemyDevourState(this);
        EnemyPossessedState = new EnemyPossessedState(this);

        box = GetComponent<BoxCollider2D>();
        utils = GetComponent<MovementUtils>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override BaseState GetInitialState()
    {
        return EnemyGuardState;
    }

    public void Interact(PlayerStateManager interactor)
    {
        IInteractable interactiveState = currentState as IInteractable;

        if(interactiveState != null)
            interactiveState.Interact(interactor);
    }

    public void DisplayPrompt(int playerId)
    {
        IInteractable interactiveState = currentState as IInteractable;

        if(interactiveState != null)
        {
            interactiveState.DisplayPrompt(playerId);
        }
    }

}
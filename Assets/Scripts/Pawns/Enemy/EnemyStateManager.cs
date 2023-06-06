using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : BaseStateManager, IInteractable
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public BoxCollider2D box;
    public GameObject heart;
    public GameObject blood;

    public bool Patrol;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public PlayerStateManager controller;

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
    }

    public override void Start()
    {
        base.Start();
    }

    public override BaseState GetInitialState()
    {
        if (Patrol)
            return EnemyPatrolState;
        else
            return EnemyGuardState;
    }

    public void Interact(PlayerStateManager interactor)
    {
        controller = interactor;
        this.SwitchState(this.EnemyPossessedState);
    }

}
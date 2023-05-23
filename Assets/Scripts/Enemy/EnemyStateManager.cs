using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : BaseStateManager
{

    public Transform target;

    public BaseState EnemyGuardState;
    public BaseState EnemyAttackState;

    void Awake()
    {
        EnemyGuardState = new EnemyGuardState(this);
        EnemyAttackState = new EnemyAttackState(this);
    }

    public override void Start()
    {
        base.Start();
    }

    public override BaseState GetInitialState()
    {
        return EnemyGuardState;
    }

}

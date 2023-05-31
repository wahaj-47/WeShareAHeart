using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateManager : BaseStateManager
{
    public Animator animator;
    public BoxCollider2D box;

    public BaseState DoorOpenState;
    public BaseState DoorClosedState;

    void Awake()
    {
        DoorOpenState = new DoorOpenState(this);
        DoorClosedState = new DoorClosedState(this);
    }

    public override BaseState GetInitialState()
    {
        return DoorClosedState;
    }
}

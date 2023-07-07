using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStateManager : BaseStateManager, IInteractable
{
    public bool elastic;
    public Animator animator;
    public TargetStateManager[] targets;

    [HideInInspector]
    public PlayerStateManager interactor;

    [field: SerializeField]
    public GameObject UI { get; set; }

    public BaseState LeverOpenState;
    public BaseState LeverOpenHeldState;
    public BaseState LeverClosedState;

    public State InitialState;

    void Awake()
    {
        LeverOpenState = new LeverOpenState(this);
        LeverOpenHeldState = new LeverOpenHeldState(this);
        LeverClosedState = new LeverClosedState(this);
    }

    public void Interact(PlayerStateManager interactor)
    {
        this.interactor = interactor;

        foreach (TargetStateManager target in targets)
        {
            target.FlipState();
        }

        ((IInteractable)currentState).Interact(interactor);
    }

    public override BaseState GetInitialState()
    {
        if (InitialState == State.Open)
            return LeverOpenState;
        return LeverClosedState;
    }

}

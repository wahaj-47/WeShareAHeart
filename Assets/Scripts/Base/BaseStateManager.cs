using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateManager : MonoBehaviour
{
    public BaseState currentState;

    // Start is called before the first frame update
    public virtual void Start()
    {
        currentState = GetInitialState();
        if(currentState != null)
            currentState.EnterState();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (currentState != null)
            currentState.UpdateState();
    }

    public virtual void FixedUpdate()
    {
        if (currentState != null)
            currentState.FixedUpdateState();
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (currentState != null)
            currentState.OnCollisionEnter2D(other);
    }

    public virtual void SwitchState(BaseState state)
    {
        currentState = state;
        if (currentState != null)
            currentState.EnterState();
    }

    public virtual BaseState GetInitialState()
    {
        return null;
    }

    public IEnumerator DoCoroutine(IEnumerator coroutine)
    {
        while (coroutine.MoveNext())
            yield return coroutine.Current;
    }
}

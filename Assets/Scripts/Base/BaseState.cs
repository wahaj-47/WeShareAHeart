using UnityEngine;

public abstract class BaseState
{
    protected BaseStateManager manager;

    public BaseState(BaseStateManager manager)
    {
        this.manager = manager;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void OnCollisionEnter2D(Collision2D other) { }
    public virtual void OnTriggerStay2D(Collider2D other) { }
    public virtual void OnTriggerExit2D(Collider2D other) { }

}

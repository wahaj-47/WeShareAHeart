using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPossessedState : BaseState
{
    private float time = 0.5f;
    private Vector2 movement;
    private float moveSpeed = 25f;
    private IInteractable interactable;

    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = 0.05f;

    public EnemyPossessedState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        DOTween.To(() => ((EnemyStateManager)manager).sprite.color, x => ((EnemyStateManager)manager).sprite.color = x, new Color(255, 255, 0, 1), 0.5f);
        ((EnemyStateManager)manager).controller.SwitchState(((EnemyStateManager)manager).controller.GhostMasterState);
        ((EnemyStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Ignore Player");
    }

    public override void UpdateState()
    {
        ((EnemyStateManager)manager).controller.transform.position = ((EnemyStateManager)manager).transform.position;

        movement.x = Input.GetAxisRaw("Player" + ((EnemyStateManager)manager).controller.playerId + "Horizontal");

        if(movement.x != 0)
        {
            ((EnemyStateManager)manager).animator.SetFloat("Velocity", moveSpeed);
        }
        else
        {
            ((EnemyStateManager)manager).animator.SetFloat("Velocity", 0);
        }

        if (movement.x < 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (movement.x > 0)
        {
            ((EnemyStateManager)manager).transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        if (Input.GetButtonDown("Fire" + ((EnemyStateManager)manager).controller.playerId))
        {
            if (this.interactable != null)
            {
                this.interactable.Interact(((EnemyStateManager)manager).controller);
            }
            else
            {
                ((EnemyStateManager)manager).StartCoroutine("DoCoroutine", this.Depossess());
            }
        }

        if (Input.GetButtonUp("Fire" + ((EnemyStateManager)manager).controller.playerId))
        {
            ((EnemyStateManager)manager).StopCoroutine("DoCoroutine");
        }
    }

    public override void FixedUpdateState()
    {
        if (((EnemyStateManager)manager).utils.IsGrounded())
        {
            if (movement.x != 0)
            {
                float dot = ((EnemyStateManager)manager).utils.CheckSlope();

                if (dot < 0) DOTween.To(() => moveSpeed, x => moveSpeed = x, 100f, 0.05f);
                else if (dot > 0) DOTween.To(() => moveSpeed, x => moveSpeed = x, 15f, 0.05f);
                else DOTween.To(() => moveSpeed, x => moveSpeed = x, 30f, 0.12f);
            }
            else moveSpeed = 30f;
        }
        else moveSpeed = 0f;

        Vector3 targetVelocity = movement * moveSpeed * Time.fixedDeltaTime * 10f;
        ((EnemyStateManager)manager).rb.velocity = Vector3.SmoothDamp(((EnemyStateManager)manager).rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            this.interactable = interactable;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (this.interactable != null)
        {
            this.interactable = null;
        }
    }

    private IEnumerator Depossess()
    {
        yield return new WaitForSeconds(time);

        DOTween.To(() => ((EnemyStateManager)manager).sprite.color, x => ((EnemyStateManager)manager).sprite.color = x, new Color(255, 255, 255, 1), 0.5f);
        ((EnemyStateManager)manager).controller.SwitchState(((EnemyStateManager)manager).controller.GhostRoamState);
        ((EnemyStateManager)manager).SwitchState(((EnemyStateManager)manager).EnemyGuardState);
    }

}

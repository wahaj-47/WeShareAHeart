using UnityEngine;
using DG.Tweening;

public class PlayerGhostRoamState : PlayerBaseState
{

    public PlayerGhostRoamState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        base.EnterState();

        DOTween.To(() => ((PlayerStateManager)manager).sprite.color, x => ((PlayerStateManager)manager).sprite.color = x, new Color(255, 255, 255, 1), 0.5f);
        DOTween.To(() => ((PlayerStateManager)manager).transform.localScale, x => ((PlayerStateManager)manager).transform.localScale = x, new Vector3(1f, 1f, 1f), 0.5f);
        ((PlayerStateManager)manager).gameObject.tag = "Ghost";
        ((PlayerStateManager)manager).rb.gravityScale = 0f;
        ((PlayerStateManager)manager).gameObject.layer = LayerMask.NameToLayer("Ghost");
        ((PlayerStateManager)manager).animator.SetBool("hasHeart", false);
        ((PlayerStateManager)manager).capsule.isTrigger = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ((PlayerStateManager)manager).animator.SetBool("isMoving", base.movement.x != 0);

        base.movement.y = Input.GetAxisRaw("Player" + ((PlayerStateManager)manager).playerId + "Vertical");

        if (Input.GetButtonDown("Fire" + ((PlayerStateManager)manager).playerId))
        {
            if (((PlayerStateManager)manager).interactable != null)
            {
                ((PlayerStateManager)manager).interactable.Interact((PlayerStateManager)manager);
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.gameObject.tag == "Heart")
        {
            int spawnerId = other.gameObject.GetComponent<Spawner>().playerId;

            if (spawnerId == ((PlayerStateManager)manager).playerId) return;

            GameObject.Destroy(other.gameObject);

            ((PlayerStateManager)manager).animator.SetBool("turningHuman", true);

            // Reset "throwing" bool parameter
            ((PlayerStateManager)manager).animator.SetBool("throwing", false);

            ((PlayerStateManager)manager).SwitchState(((PlayerStateManager)manager).HumanRoamState);
        }
   
    }

}

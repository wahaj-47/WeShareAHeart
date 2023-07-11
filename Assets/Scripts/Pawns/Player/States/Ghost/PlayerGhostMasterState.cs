using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGhostMasterState : PlayerBaseState
{
    public PlayerGhostMasterState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        DOTween.To(() => ((PlayerStateManager)manager).sprite.color, x => ((PlayerStateManager)manager).sprite.color = x, new Color(255, 255, 255, 0), 0.5f);
        DOTween.To(() => ((PlayerStateManager)manager).transform.localScale, x => ((PlayerStateManager)manager).transform.localScale = x, new Vector3(0.8f,0.8f,0.8f), 0.5f);
    }


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Enemy")
        {
            IInteractable interactable = other.GetComponent<IInteractable>();

            if (interactable != null)
            {
                ((PlayerStateManager)manager).interactable = interactable;
                ((PlayerStateManager)manager).interactable.DisplayPrompt(((PlayerStateManager)manager).playerId);
            }
        }
    }
}

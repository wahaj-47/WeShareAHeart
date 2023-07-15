using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGhostMasterState : PlayerBaseState
{
    public PlayerGhostMasterState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((PlayerStateManager)manager).gameObject.GetComponent<PlayerAudioManager>().Play("Possess");
        DOTween.To(() => ((PlayerStateManager)manager).sprite.color, x => ((PlayerStateManager)manager).sprite.color = x, new Color(255, 255, 255, 0), 0.5f);
        DOTween.To(() => ((PlayerStateManager)manager).transform.localScale, x => ((PlayerStateManager)manager).transform.localScale = x, new Vector3(0.8f,0.8f,0.8f), 0.5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGhostMasterState : PlayerBaseState
{
    public PlayerGhostMasterState(PlayerStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        DOTween.To(() => ((PlayerStateManager)manager).transform.localScale, x => ((PlayerStateManager)manager).transform.localScale = x, Vector3.zero, 0.5f);
    }
}

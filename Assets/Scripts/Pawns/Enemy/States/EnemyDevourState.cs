using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevourState : BaseState
{
    public EnemyDevourState(EnemyStateManager manager) : base(manager) { }

    public override void EnterState()
    {
        ((EnemyStateManager)manager).animator.SetBool("hasHeart", true);
        ((EnemyStateManager)manager).heart.SetActive(true);
        ((EnemyStateManager)manager).StartCoroutine("DoCoroutine", this.Chew());
    }

    IEnumerator Chew()
    {
        yield return new WaitForSeconds(1f);
        ((EnemyStateManager)manager).blood.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        DOTween.To(() => sprite.color, x => sprite.color = x, new Color(255, 255, 255, 0), 2f);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

}

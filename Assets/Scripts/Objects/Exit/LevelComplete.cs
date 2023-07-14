using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]
public class LevelComplete : MonoBehaviour
{
    private bool human = false;
    private bool ghost = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!StateManager.instance.heartInScene)
        {
            if (other.gameObject.TryGetComponent(out PlayerStateManager player))
            {
                if (other.gameObject.tag == "Human")
                {
                    human = true;

                    Vector3 targetPos = transform.position;
                    targetPos.y = other.gameObject.transform.position.y;

                    DOTween.To(() => other.gameObject.transform.position, x => other.gameObject.transform.position = x, targetPos, 0.5f);
                }

                if (other.gameObject.tag == "Ghost") 
                {
                    ghost = true;
                    DOTween.To(() => other.gameObject.transform.position, x => other.gameObject.transform.position = x, transform.position, 0.5f);
                }

                player.SwitchState(player.PlayerPauseState);
                DOTween.To(() => player.sprite.color, x => player.sprite.color = x, new Color(255, 255, 255, 0), 1f);
            }
        }
    }

    void Update()
    {
        if(human && ghost)
        {
            LevelLoader.instance.LoadNextLevel();
        }
    }
}

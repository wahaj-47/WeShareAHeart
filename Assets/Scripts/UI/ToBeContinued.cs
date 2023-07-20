using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ToBeContinued : MonoBehaviour
{

    [SerializeField] private SpriteRenderer heart;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D spriteLight;

    void Awake()
    {
        Cursor.visible = true;
        heart.GetComponent<Animator>().SetBool("Slow", true);
    }

    void Start()
    {
        AudioManager.instance.Play("Theme", 1f);
        Tween myTween = DOTween.To(() => spriteLight.intensity, x => spriteLight.intensity = x, 2f, 0.6f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.6f);
    }

    public void MainMenu()
    {
        AudioManager.instance.PlayOnce("Start");
        LevelLoader.instance.LoadLevelByName("MainMenu");
    }

}


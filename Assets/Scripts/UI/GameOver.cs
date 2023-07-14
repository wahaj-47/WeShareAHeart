using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] private SpriteRenderer heart;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D spriteLight;


    void Awake()
    {
        heart.GetComponent<Animator>().SetBool("Slow", true);
    }

    void Start()
    {
        StartCoroutine(StopBeating());
    }

    IEnumerator StopBeating()
    {
        Tween myTween = DOTween.To(() => spriteLight.intensity, x => spriteLight.intensity = x, 2f, 0.6f).SetLoops(6, LoopType.Yoyo);
        yield return myTween.WaitForCompletion();
        heart.GetComponent<Animator>().SetBool("Alive", false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        LevelLoader.instance.LoadLevelByName("LevelOne");
    }
}

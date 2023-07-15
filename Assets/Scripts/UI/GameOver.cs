using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        AudioManager.instance.Play("Theme", 1f);
        StartCoroutine(StopBeating());
    }

    IEnumerator StopBeating()
    {
        Tween myTween = DOTween.To(() => spriteLight.intensity, x => spriteLight.intensity = x, 2f, 0.6f).SetLoops(6, LoopType.Yoyo).SetDelay(0.6f);
        yield return new WaitForSeconds(3.2f);
        heart.GetComponent<Animator>().SetBool("Alive", false);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlayOnce("Start");
        Application.Quit();
    }

    public void Retry()
    {
        AudioManager.instance.PlayOnce("Start");
        LevelLoader.instance.LoadLevelByName("LevelOne");
    }
}

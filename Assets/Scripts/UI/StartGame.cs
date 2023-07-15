using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI prompt;

    private bool inputEnabled = false;

    void Start()
    {
        StartCoroutine(IntroAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled)
        {
            if (Input.anyKey)
            {
                AudioManager.instance.Play("Start");
                AudioManager.instance.StopPlaying("Theme");
                LevelLoader.instance.LoadLevelByName("LevelOne");
            }
        }
    }

    IEnumerator IntroAnimation()
    {
        Tween titleTween = DOTween.To(() => title.color, x => title.color = x, new Color(255, 255, 255, 1), 1f).SetDelay(2f);
        DOTween.To(() => prompt.color, x => prompt.color = x, new Color(255, 255, 255, 1), 1f).SetLoops(-1, LoopType.Yoyo).SetDelay(2f);
        yield return titleTween.WaitForCompletion();
        inputEnabled = true;
    }
}

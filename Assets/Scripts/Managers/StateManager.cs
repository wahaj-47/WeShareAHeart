using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;

    public bool heartInScene = false;

    [SerializeField] private PlayerStateManager playerOne;
    [SerializeField] private PlayerStateManager playerTwo;

    private BaseState playerOneLastState;
    private BaseState playerTwoLastState;

    [SerializeField] private float deathTimerDuration = 3.5f;
    private Coroutine coroutine;

    [SerializeField] private Volume deathVolume;

    void Awake()
    {
        Cursor.visible = false;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        AudioManager.instance.Play("Ambience");
    }

    public void StartDeathTimer()
    {
        heartInScene = true;
        coroutine = StartCoroutine(Countdown());
    }

    public void StopDeathTimer()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = null;
        heartInScene = false;
    }

    public void DisablePlayers()
    {
        playerOneLastState = playerOne.currentState;
        playerOne.SwitchState(playerOne.PlayerPauseState);

        playerTwoLastState = playerTwo.currentState;
        playerTwo.SwitchState(playerTwo.PlayerPauseState);
    }

    public void EnablePlayers()
    {
        playerOne.SwitchState(playerOneLastState);
        playerTwo.SwitchState(playerTwoLastState);
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(deathTimerDuration);
        Time.timeScale = 0.5f;
        Tween deathTween = DOTween.To(() => deathVolume.weight, x => deathVolume.weight = x, 1, 1f);
        yield return deathTween.WaitForCompletion();
        Time.timeScale = 1f;
        LevelLoader.instance.LoadLevelByName("GameOver");
    }

    
}

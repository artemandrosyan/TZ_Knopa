using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private const float DELAY_TIME = 0.01f;
    private const float AMOUNT_PART = 0.01f;
    [SerializeField]
    private Image fillBar;
    WaitForSecondsRealtime waitTime = new WaitForSecondsRealtime(DELAY_TIME);
    private GameStateMachine _gameStateMachine;


    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Awake()
    {
        fillBar.fillAmount = 0f;
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        for (int i = 0; i < 100; i++)
        {
            fillBar.fillAmount += AMOUNT_PART;
            yield return waitTime;
        }
        _gameStateMachine.Enter<GameLoopState>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    private GameStateMachine _gameStateMachine;


    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
    }

    private void Play()
    {
        _gameStateMachine.Enter<LoadScreenState>();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void RemoveListeners()
    {
        playButton.onClick.RemoveListener(Play);
    }
}

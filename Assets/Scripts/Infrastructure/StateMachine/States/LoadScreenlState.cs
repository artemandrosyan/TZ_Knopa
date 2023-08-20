using UnityEngine;

public class LoadScreenState : IState
{
    private const string LOADING = "Loading";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;

    public LoadScreenState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
    {
        _stateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _sceneLoader.Load(LOADING, onLoaded);
    }

    public void Exit()
    {

    }

    private void onLoaded()
    {
        InitUI();
    }

    private void InitUI()
    {
        LoadingScreen loadingScreen = _gameFactory.CreateLoadingGameCanvas();
        loadingScreen.Construct(_stateMachine);
    }
}
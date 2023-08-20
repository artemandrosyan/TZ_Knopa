using UnityEngine;
public class BootstrapState : IState
{
    private const string MENU = "Menu";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _sceneLoader.Load(MENU, onLoaded);
    }

    private void onLoaded()
    {
        InitUI();
    }

    private void InitUI()
    {
        MenuUI menuUI = _gameFactory.CreateMenuCanvas();
        menuUI.Construct(_stateMachine);
    }

    public void Exit()
    {
    }

}
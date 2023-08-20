using UnityEngine;

public class GameLoopState : IState
{
    private const string MAIN = "Main";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
    {
        _stateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _sceneLoader.Load(MAIN, onLoaded);
    }

    public void Exit()
    {

    }

    private void onLoaded()
    {
        InputService inputService = _gameFactory.CreateHUD();
        HeroMove heroMove = _gameFactory.CreatePlayer();
        heroMove.Construct(inputService);
    }

}

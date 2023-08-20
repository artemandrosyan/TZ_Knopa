public class Game
{
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner)
    {
        IAssetProvider assetsProvier = new AssetProvider();
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new GameFactory(assetsProvier));
    }
}

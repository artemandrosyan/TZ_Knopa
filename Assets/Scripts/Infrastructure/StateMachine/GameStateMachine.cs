using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, IGameFactory gameFactory)
    {
        _states = new Dictionary<Type, IExitableState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, gameFactory),
            [typeof(LoadScreenState)] = new LoadScreenState(this, sceneLoader, gameFactory),
            [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader, gameFactory),
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();

        TState state = GetState<TState>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
}
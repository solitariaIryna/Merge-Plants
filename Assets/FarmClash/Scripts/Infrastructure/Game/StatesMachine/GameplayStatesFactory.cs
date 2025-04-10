using MergePlants.Infrastructure.StateMachine;
using System;
using System.Collections.Generic;
using Zenject;


namespace MergePlants.Infrastructure.Gameplay.StatesMachine
{
    public class GameplayStatesFactory
    {
        private readonly DiContainer _container;

        public GameplayStatesFactory(DiContainer container)
        {
            _container = container;
        }

        public Dictionary<Type, IExitableState> CreateStates() => new Dictionary<Type, IExitableState>
        {
            { typeof(LoadLevelState), _container.Instantiate<LoadLevelState>() },
            { typeof(GameLoopState), _container.Instantiate<GameLoopState>() },
            { typeof(WinGameState), _container.Instantiate<WinGameState>() },
            { typeof(LoseGameState), _container.Instantiate<LoseGameState>() }
        };
    }
}

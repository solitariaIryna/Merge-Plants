using FarnClash.Infrastructure.StateMachine;
using System;
using System.Collections.Generic;
using Zenject;


namespace FarnClash.Infrastructure.Gameplay.StatesMachine
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
            { typeof(LoadBattleState), _container.Instantiate<LoadBattleState>() },
            { typeof(GameLoopState), _container.Instantiate<GameLoopState>() },
            { typeof(WinGameState), _container.Instantiate<WinGameState>() },
            { typeof(LoseGameState), _container.Instantiate<LoseGameState>() }
        };
    }
}

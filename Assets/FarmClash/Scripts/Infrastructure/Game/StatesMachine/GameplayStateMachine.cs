﻿using MergePlants.Infrastructure.StateMachine;

namespace MergePlants.Infrastructure.Gameplay.StatesMachine
{
    public class GameplayStateMachine : BaseStateMachine
    {
        private GameplayStatesFactory _gameplayStatesFactory;

        public GameplayStateMachine(GameplayStatesFactory gameplayStatesFactory)
        {
            _gameplayStatesFactory = gameplayStatesFactory;
        }

        public override void Initialize()
        {
            _states = _gameplayStatesFactory.CreateStates();
        }
    }
}

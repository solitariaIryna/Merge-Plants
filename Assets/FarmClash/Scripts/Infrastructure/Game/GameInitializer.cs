using MergePlants.Infrastructure.Gameplay.StatesMachine;
using Zenject;

namespace MergePlants.Infrastructure
{
    public class GameInitializer : IInitializable
    {
        private readonly GameplayStateMachine _gameplayStateMachine;

        public GameInitializer(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }
        public void Initialize()
        {
            _gameplayStateMachine.Initialize();
            _gameplayStateMachine.EnterAsync<LoadLevelState>();
        }
    }
}

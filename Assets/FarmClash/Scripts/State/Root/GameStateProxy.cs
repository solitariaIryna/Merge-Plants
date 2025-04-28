using MergePlants.State.GameResources;
using MergePlants.State.Levels;
using ObservableCollections;
using R3;
using System.Linq;

namespace MergePlants.State.Root
{
    public class GameStateProxy
    {
        private readonly GameState _gameState;
        public readonly ReactiveProperty<int> CurrentLevelId = new();

        public ObservableList<Level> Levels { get; } = new();
        public ObservableList<Resource> Resources { get; } = new();

        public GameState GameState => _gameState;

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;

            InitResources(gameState);

            CurrentLevelId.Subscribe(newValue => gameState.CurrentLevelId = newValue);
        }
        public int CreateEntityId() =>
            _gameState.CreateEntityId();
        public void InitLevel(Level level)
        {
            _gameState.Levels.ForEach(levelData => Levels.Add(level));

            Levels.ObserveAdd().Subscribe(e =>
            {
                var addedLevel = e.Value;
                _gameState.Levels.Add(addedLevel.Data);
            });

            Levels.ObserveRemove().Subscribe(e =>
            {
                var removedLevel = e.Value;
                var removedLevelState = _gameState.Levels.FirstOrDefault(b => b.Id == removedLevel.Id);
                _gameState.Levels.Remove(removedLevelState);
            });

        }   
        private void InitResources(GameState gameState)
        {
            gameState.Resources.ForEach(resourceData => Resources.Add(new Resource(resourceData)));

            Resources.ObserveAdd().Subscribe(e =>
            {
                var addedResource = e.Value;
                gameState.Resources.Add(addedResource.Data);
            });

            Resources.ObserveRemove().Subscribe(e =>
            {
                var removedResource = e.Value;
                var removedResourceData = gameState.Resources.FirstOrDefault(b => b.ResourceType == removedResource.ResourceType);
                gameState.Resources.Remove(removedResourceData);
            });
        }
    
    }
}

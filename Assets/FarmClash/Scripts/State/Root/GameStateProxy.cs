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
        private readonly ReactiveProperty<int> CurrentMapId = new();

        public ObservableList<Level> Levels { get; } = new();
        public ObservableList<Resource> Resources { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;

            InitLevel(gameState);
            InitResources(gameState);

            CurrentMapId.Subscribe(newValue => gameState.CurrentLevelId = newValue);
        }
        public int CreateEntityId() =>
            _gameState.CreateEntityId();
        private void InitLevel(GameState gameState)
        {
            gameState.Levels.ForEach(levelData => Levels.Add(new Level(levelData)));

            Levels.ObserveAdd().Subscribe(e =>
            {
                var addedLevel = e.Value;
                gameState.Levels.Add(addedLevel.Data);
            });

            Levels.ObserveRemove().Subscribe(e =>
            {
                var removedLevel = e.Value;
                var removedLevelState = gameState.Levels.FirstOrDefault(b => b.Id == removedLevel.Id);
                gameState.Levels.Remove(removedLevelState);
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

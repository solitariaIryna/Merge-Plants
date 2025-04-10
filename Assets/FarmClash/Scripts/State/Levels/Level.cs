using System.Linq;
using MergePlants.State.Entities;
using ObservableCollections;
using R3;

namespace MergePlants.State.Levels
{
    public class Level
    {
        public int Id => Data.Id;
        public ObservableList<Entity> Entities { get; } = new();
        public LevelData Data { get; }
        public Level(LevelData gameData)
        {
            Data = gameData;
            gameData.Entities.ForEach(entityData => Entities.Add(EntitiesFactory.CreateEntity(entityData)));

            Entities.ObserveAdd().Subscribe(eventData =>
            {
                var addedEntity = eventData.Value;
                gameData.Entities.Add(addedEntity.Data);
            });
            Entities.ObserveRemove().Subscribe(eventData =>
            {
                var removedEntity = eventData.Value;
                var removedEntityData = gameData.Entities.FirstOrDefault(e => e.UniqueId == removedEntity.UniqueId);
                gameData.Entities.Remove(removedEntityData);
            });

        }
    }

}

using System.Collections.Generic;
using System.Linq;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Cells;
using ObservableCollections;
using R3;

namespace MergePlants.State.Levels
{
    public class Level
    {
        public int Id => Data.Id;
        public ObservableList<Entity> Entities { get; } = new();
        public ObservableList<CellEntity> Cells { get; } = new();
        public LevelData Data { get; }
        public Level(LevelData gameData)
        {
            Data = gameData;
            gameData.Entities.ForEach(entityData => Entities.Add(EntitiesFactory.CreateEntity(entityData)));
            gameData.Cells.ForEach(cellsData => Cells.Add((CellEntity)EntitiesFactory.CreateEntity(cellsData)));

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

            Cells.ObserveAdd().Subscribe(eventData =>
            {
                var addedCell = eventData.Value;
                gameData.Cells.Add((CellEntityData)addedCell.Data);
 
            });

        }
    }

}

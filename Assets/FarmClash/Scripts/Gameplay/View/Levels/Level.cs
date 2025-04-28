using System.Linq;
using MergePlants.Configs.Enemies;
using MergePlants.Gameplay;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Cells;
using ObservableCollections;
using R3;
using UnityEngine;
using Zenject;

namespace MergePlants.State.Levels
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public Transform CellsParent { get; private set; }
        [SerializeField] private EnemiesSpawner _enemiesSpawmer;
        [SerializeField] private EnemiesWaveConfig _waveConfig;
        public int Id => Data.Id;
        public ObservableList<Entity> Entities { get; } = new();
        public ObservableList<CellEntity> Cells { get; } = new();
        public LevelData Data { get; private set; }

        private EntitiesFactory _entitiesFactory;

        [Inject]
        private void Construct(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        private void Start()
        {
            _enemiesSpawmer.StartSpawnEnemy(_waveConfig);
        }
        public void SetData(LevelData levelData)
        {
            Data = levelData;

            levelData.Entities.ForEach(entityData => Entities.Add(_entitiesFactory.CreateEntity(entityData)));
            levelData.Cells.ForEach(cellsData => Cells.Add((CellEntity)_entitiesFactory.CreateEntity(cellsData)));

            Entities.ObserveAdd().Subscribe(eventData =>
            {
                var addedEntity = eventData.Value;
                levelData.Entities.Add(addedEntity.Data);
            });
            Entities.ObserveRemove().Subscribe(eventData =>
            {
                var removedEntity = eventData.Value;
                var removedEntityData = levelData.Entities.FirstOrDefault(e => e.UniqueId == removedEntity.UniqueId);
                levelData.Entities.Remove(removedEntityData);
            });

            Cells.ObserveAdd().Subscribe(eventData =>
            {
                var addedCell = eventData.Value;
                levelData.Cells.Add((CellEntityData)addedCell.Data);

            });
        }
    }

}

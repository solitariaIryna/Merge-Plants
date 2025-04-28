using MergePlants.Gameplay.View.Bullets;
using MergePlants.Services.AssetProvider;
using MergePlants.State.Entities.Bullets;
using MergePlants.State.Entities.Cells;
using MergePlants.State.Entities.Enemies;
using MergePlants.State.Entities.Plants;
using Zenject;

namespace MergePlants.State.Entities
{
    public class EntitiesFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

        public EntitiesFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assetProvider = assetProvider;
            _container = container;
        }

        public Entity CreateEntity(EntityData entityData)
        {
            return entityData.Type switch
            {
                EntityType.Plant => CreatePlant(entityData as PlantEntityData),
                EntityType.Cell => CreateCell(entityData as CellEntityData),
                EntityType.Enemy => CreateEnemy(entityData as EnemyEntityData),
                EntityType.Bullet => CreateBullet(entityData as BulletEntityData),
                _ => throw new System.Exception("Unsupported entity type" + entityData.Type),
            };
        }

        private Entity CreateBullet(BulletEntityData bulletEntityData)
        {
            BulletEntity bullet = _assetProvider.Instantiate<BulletEntity>("Gameplay/Entities/Bullet", _container);
            bullet.SetData(bulletEntityData);
            return bullet;
        }

        private Entity CreateEnemy(EnemyEntityData enemyEntityData)
        {
            EnemyEntity enemy = _assetProvider.Instantiate<EnemyEntity>("Gameplay/Entities/Enemy", _container);
            enemy.SetData(enemyEntityData);
            return enemy;
        }

        private Entity CreateCell(CellEntityData cellEntityData)
        {
            CellEntity cell = _assetProvider.Instantiate<CellEntity>("Gameplay/Entities/Cell", _container);
            cell.SetData(cellEntityData);
            return cell;
        }

        private Entity CreatePlant(PlantEntityData plantEntityData)
        {
            PlantEntity plant = _assetProvider.Instantiate<PlantEntity>("Gameplay/Entities/Plant", _container);
            plant.SetData(plantEntityData);
            return plant;
        }
    }
}

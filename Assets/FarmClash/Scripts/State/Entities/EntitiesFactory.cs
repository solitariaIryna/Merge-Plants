using MergePlants.State.Entities.Cells;
using MergePlants.State.Entities.Enemies;
using MergePlants.State.Entities.Plants;

namespace MergePlants.State.Entities
{
    public static class EntitiesFactory
    {
        public static Entity CreateEntity(EntityData entityData)
        {
            return entityData.Type switch
            {
                EntityType.Plant => new PlantEntity(entityData as PlantEntityData),
                EntityType.Enemy => new EnemyEntity(entityData as EnemyEntityData),
                EntityType.Cell => new CellEntity(entityData as CellEntityData),
                _ => throw new System.Exception("Unsupported entity type" + entityData.Type),
            };
        }

    }
}

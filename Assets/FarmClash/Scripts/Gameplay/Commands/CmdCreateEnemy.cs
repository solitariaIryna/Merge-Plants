using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Enemies;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Gameplay.Services;

namespace MergePlants.Gameplay.Commands
{
    public class CmdCreateEnemy : ICommandWithResult<CmdCreateEnemyParameters, EnemyEntity>
    {
        private readonly GameStateProxy _gameState;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly EnemiesService _enemiesService;

        public CmdCreateEnemy(GameStateProxy gameState, EntitiesFactory entitiesFactory, EnemiesService enemiesService)
        {
            _gameState = gameState;
            _entitiesFactory = entitiesFactory;
            _enemiesService = enemiesService;
        }
        public CommandResult<EnemyEntity> Execute(CmdCreateEnemyParameters parameters)
        {
            int entityId = _gameState.CreateEntityId();

            EnemyEntityData newEnemyData = new EnemyEntityData
            {
                UniqueId = entityId,
                Type = EntityType.Enemy,
                EnemyType = parameters.EnemyType,
                Position = parameters.Position,
                Config = _enemiesService.GetConfigForType(parameters.EnemyType)

            };

            EnemyEntity newEnemyEntity = (EnemyEntity)_entitiesFactory.CreateEntity(newEnemyData);
            newEnemyEntity.SetPath(parameters.EnemyPath);

            return new CommandResult<EnemyEntity>(true, newEnemyEntity);
        }
    }
}

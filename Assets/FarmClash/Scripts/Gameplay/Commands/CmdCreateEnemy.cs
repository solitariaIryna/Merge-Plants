using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Enemies;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Commands
{
    public class CmdCreateEnemy : ICommandWithResult<CmdCreateEnemyParameters, EnemyEntity>
    {
        private readonly GameStateProxy _gameState;
        public CmdCreateEnemy(GameStateProxy gameState)
        {
            _gameState = gameState;
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

            };

            EnemyEntity newEnemyEntity = new EnemyEntity(newEnemyData, parameters.EnemyPath);

            return new CommandResult<EnemyEntity>(true, newEnemyEntity);
        }
    }
}

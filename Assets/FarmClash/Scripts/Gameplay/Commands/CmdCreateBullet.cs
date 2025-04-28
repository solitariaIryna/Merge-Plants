using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Entities;
using MergePlants.Gameplay.View.Bullets;
using MergePlants.State.Entities.Bullets;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Commands
{
    public class CmdCreateBullet : ICommandWithResult<CmdCreateBulletParameters, BulletEntity>
    {
        private readonly GameStateProxy _gameState;
        private readonly EntitiesFactory _entitiesFactory;

        public CmdCreateBullet(GameStateProxy gameState, EntitiesFactory entitiesFactory)
        {
            _gameState = gameState;
            _entitiesFactory = entitiesFactory;
        }
        public CommandResult<BulletEntity> Execute(CmdCreateBulletParameters parameters)
        {
            int entityId = _gameState.CreateEntityId();

            BulletEntityData newBulletData = new BulletEntityData
            {
                UniqueId = entityId,
                Type = EntityType.Bullet,
                Position = parameters.Position,
                Target = parameters.Target

            };

            BulletEntity newBulletEntity = (BulletEntity)_entitiesFactory.CreateEntity(newBulletData);

            return new CommandResult<BulletEntity>(true, newBulletEntity);
            }
    }
}

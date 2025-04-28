using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Levels;
using System.Linq;
using UnityEngine;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Cells;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Commands
{
    public class CmdCreateCell : ICommandWithResult<CmdCreateCellParameters, CellEntity>
    {
        private readonly GameStateProxy _gameState;
        private readonly EntitiesFactory _entitiesFactory;

        public CmdCreateCell(GameStateProxy gameState, EntitiesFactory entitiesFactory)
        {
            _gameState = gameState;
            _entitiesFactory = entitiesFactory;
        }
        public CommandResult<CellEntity> Execute(CmdCreateCellParameters parameters)
        {
            Level currentLevel = _gameState.Levels.FirstOrDefault(l => l.Id == _gameState.CurrentLevelId.CurrentValue);

            if (currentLevel == null)
            {
                Debug.LogError($"Couldn't find Level for id: {_gameState.CurrentLevelId.CurrentValue}");
                return new CommandResult<CellEntity>(false, null);
            }

            int entityId = _gameState.CreateEntityId();

            CellEntityData newCelldata = new CellEntityData
            {
                UniqueId = entityId,
                CellId = parameters.CellId,
                Type = EntityType.Cell,
                Position = parameters.Position,
                Bought = parameters.Bought,
                OccupiedByPlantId = -1
            };

            CellEntity newCellEntity = (CellEntity)_entitiesFactory.CreateEntity(newCelldata);

            currentLevel.Cells.Add(newCellEntity);

            return new CommandResult<CellEntity>(true, newCellEntity);
        }
    }
}

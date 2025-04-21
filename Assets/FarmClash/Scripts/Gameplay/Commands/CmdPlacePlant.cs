using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Levels;
using System.Linq;
using UnityEngine;
using MergePlants.State.Entities.Plants;
using MergePlants.State.Entities;
using MergePlants.Gameplay.Services;
using MergePlants.State.Entities.Cells;

namespace MergePlants.Gameplay.Commands
{
    public class CmdPlacePlant : ICommandWithResult<CmdPlacePlantParameters, PlantEntity>
    {
        private readonly GameStateProxy _gameState;
        private readonly CellsService _cellsService;
        public CmdPlacePlant(GameStateProxy gameState, CellsService cellsService)
        {
            _gameState = gameState;
            _cellsService = cellsService;
        }

        public CommandResult<PlantEntity> Execute(CmdPlacePlantParameters parameters)
        {
            Level currentLevel = _gameState.Levels.FirstOrDefault(l => l.Id == _gameState.CurrentLevelId.CurrentValue);

            if (currentLevel == null)
            {
                Debug.LogError($"Couldn't find Level for id: {_gameState.CurrentLevelId.CurrentValue}");
                return new CommandResult<PlantEntity>(false, null);
            }

            int entityId = _gameState.CreateEntityId();

            Vector3 position;

            if (_cellsService.TryBusyCell(parameters.CellId, entityId, out CellEntity cell))
            {
                position = cell.Position;

                PlantEntityData newPlantData = new PlantEntityData
                {
                    UniqueId = entityId,
                    CellId = parameters.CellId,
                    Level = parameters.Level,
                    Type = EntityType.Plant,
                    Position = position,

                };

                PlantEntity newPlantEntity = new PlantEntity(newPlantData);

                currentLevel.Entities.Add(newPlantEntity);

                return new CommandResult<PlantEntity>(true, newPlantEntity);
            }
            Debug.LogError($"Couldn't place Plant with id: {entityId}. Cell with Id: {parameters.CellId} already busy");
            return new CommandResult<PlantEntity>(false, null);
        }
    }
}

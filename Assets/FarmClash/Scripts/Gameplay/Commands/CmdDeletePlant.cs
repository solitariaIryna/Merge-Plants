using MergePlants.Services.Command;
using MergePlants.State.Root;
using MergePlants.State.Levels;
using System.Linq;
using UnityEngine;
using MergePlants.Gameplay.Services;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Commands
{
    public class CmdDeletePlant : ICommand<CmdDeletePlantParameters>
    {
        private readonly GameStateProxy _gameState;
        private readonly CellsService _cellsService;
        private readonly PlantsService _plantsService;

        public CmdDeletePlant(GameStateProxy gameState, CellsService cellsService, PlantsService plantsService)
        {
            _gameState = gameState;
            _cellsService = cellsService;
            _plantsService = plantsService;
        }
        public bool Execute(CmdDeletePlantParameters parameters)
        {
            Level currentLevel = _gameState.Levels.FirstOrDefault(l => l.Id == _gameState.CurrentLevelId.CurrentValue);

            if (currentLevel == null)
            {
                Debug.LogError($"Couldn't find Level for id: {_gameState.CurrentLevelId.CurrentValue}");
                return false;
            }
            parameters.Plant.Die()
;            _cellsService.FreeCell(parameters.Plant.CellId.Value);
                       
            currentLevel.Entities.Remove(parameters.Plant);

            return true;
        }
    }
}

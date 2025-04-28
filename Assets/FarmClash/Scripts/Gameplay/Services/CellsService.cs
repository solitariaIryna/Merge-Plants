using MergePlants.Services.Command;
using ObservableCollections;
using System.Collections.Generic;
using MergePlants.Services.SaveLoad;
using MergePlants.State.Entities.Cells;
using UnityEngine;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Services
{
    public class CellsService
    {
        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<CellEntity> _allCells = new();
        private readonly Dictionary<int, CellEntity> _cellsMap = new();

        public IObservableCollection<CellEntity> AllCells => _allCells;

        public CellsService(ISaveLoadService saveLoadService, ICommandProcessor commandProcessor)
        {
            _cmd = commandProcessor;

            if (saveLoadService.GameState.Levels.Count > saveLoadService.GameState.CurrentLevelId.Value)
            {
                var currentLevel = saveLoadService.GameState.Levels[saveLoadService.GameState.CurrentLevelId.Value];

                foreach (var cell in currentLevel.Cells)
                {
                    _allCells.Add(cell);
                    _cellsMap[cell.CellId] = cell;
                }

            }

        }

        public bool CreateCell(int cellId, bool bought, bool busy, Vector3 position)
        {
            var parameters = new CmdCreateCellParameters(cellId, bought, busy, position);
            CommandResult<CellEntity> result = _cmd.Process<CmdCreateCellParameters, CellEntity>(parameters);

            if (result.Success)
            {
                _allCells.Add(result.Result);
                _cellsMap[cellId] = result.Result;
            }
                

            return result.Success;
        }

        public bool TryBusyCell(int cellId, int plantId, out CellEntity cell)
        {
            cell = _cellsMap[cellId];

            if (cell.OccupiedByPlant.Value < 0)
            {
                cell.OccupiedByPlant.Value = plantId;
                return true;
            }
            return false;
        }

        public void FreeCell(int cellId)
        {
            CellEntity cell = _cellsMap[cellId];
            cell.OccupiedByPlant.Value = -1;
        }
    }
}

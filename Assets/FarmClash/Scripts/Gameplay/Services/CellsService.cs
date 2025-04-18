using MergePlants.Services.Command;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using MergePlants.Services.SaveLoad;
using MergePlants.Gameplay.View.Cells;
using MergePlants.State.Entities.Cells;
using UnityEngine;
using System.Linq;
using System;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Services
{
    public class CellsService
    {
        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<CellViewModel> _allCells = new();
        private readonly Dictionary<int, CellViewModel> _cellsMap = new();

        public IObservableCollection<CellViewModel> AllCells => _allCells;

        public ObservableList<CellEntity> Cells { get; } = new();

        public CellsService(ISaveLoadService saveLoadService, ICommandProcessor commandProcessor)
        {
            _cmd = commandProcessor;

            if (saveLoadService.GameState.Levels.Count > saveLoadService.GameState.CurrentLevelId.Value)
            {
                var currentLevel = saveLoadService.GameState.Levels[saveLoadService.GameState.CurrentLevelId.Value];

                foreach (var cell in currentLevel.Cells)
                {
                    Cells.Add(cell);
                }

                foreach (var cell in Cells)
                {
                    CreateCellViewModel(cell);
                }

            }

            Cells.ObserveAdd().Subscribe(e =>
            {
                CreateCellViewModel(e.Value);
            });

            Cells.ObserveRemove().Subscribe(e =>
            {
                RemoveCellViewModel(e.Value);
            });
        }

        public bool CreateCell(int cellId, bool bought, bool busy, Vector3 position)
        {
            var command = new CmdCreateCellParameters(cellId, bought, busy, position);
            CommandResult<CellEntity> result = _cmd.Process<CmdCreateCellParameters, CellEntity>(command);

            if (result.Success)
                Cells.Add(result.Result);

            return result.Success;
        }

        private void CreateCellViewModel(CellEntity cellEntity)
        {
            var cellViewModel = new CellViewModel(cellEntity, this);
            _allCells.Add(cellViewModel);
            _cellsMap[cellEntity.CellId] = cellViewModel;
        }

        private void RemoveCellViewModel(CellEntity cellEntity)
        {
            if (_cellsMap.TryGetValue(cellEntity.UniqueId, out var vm))
            {
                _allCells.Remove(vm);
                _cellsMap.Remove(cellEntity.UniqueId);
            }
        }

        public bool TryBusyCell(int cellId, int plantId, out CellEntity cell)
        {
            cell = Cells.FirstOrDefault(c => c.CellId == cellId);

            if (cell.OccupiedByPlant.Value < 0)
            {
                cell.OccupiedByPlant.Value = plantId;
                return true;
            }
            return false;
        }

        public void FreeCell(int cellId)
        {
            CellEntity cell = Cells.FirstOrDefault(c => c.CellId == cellId);
            cell.OccupiedByPlant.Value = -1;
        }
    }
}

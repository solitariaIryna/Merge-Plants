using MergePlants.Gameplay.Services;
using MergePlants.State.Entities.Cells;
using UnityEngine;
using R3;

namespace MergePlants.Gameplay.View.Cells
{
    public class CellViewModel
    {
        public readonly int CellId;
        public readonly int EntityId;
        private readonly CellsService _cellsService;
        public bool Bought { get; private set; }
        public int OccupiedByPlant { get; private set; }
        public Vector3 Position { get; private set; }

        public CellViewModel(CellEntity cellEntity, CellsService cellsService)
        {
            EntityId = cellEntity.UniqueId;
            CellId = cellEntity.CellId;
            Position = cellEntity.Position;
            _cellsService = cellsService;

            Bought = cellEntity.Bought.Value;
            OccupiedByPlant = cellEntity.OccupiedByPlant.Value;

            cellEntity.Bought.Subscribe(b => Bought = b);
            cellEntity.OccupiedByPlant.Subscribe(o => OccupiedByPlant = o);
        }

    }
}

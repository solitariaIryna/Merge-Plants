using MergePlants.Services.Command;
using UnityEngine;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateCellParameters : ICommandParameter
    {
        public readonly int CellId;
        public readonly bool Bought;
        public readonly bool Busy;
        public readonly Vector3 Position;

        public CmdCreateCellParameters(int cellId, bool bought, bool busy, Vector3 position)
        {
            CellId = cellId;
            Bought = bought;
            Busy = busy;
            Position = position;
        }
    }
}

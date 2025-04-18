
using MergePlants.Services.Command;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdPlacePlantParameters : ICommandParameter
    {
        public readonly int Level;
        public readonly int CellId;

        public CmdPlacePlantParameters(int level, int cellId)
        {
            Level = level;
            CellId = cellId;
        }
    }
}


using MergePlants.Services.Command;
using UnityEngine;

namespace FarmClash.Gameplay.Commands.Parameters
{
    public class CmdPlacePlantParameters : ICommandParameter
    {
        private readonly int Level;
        private readonly Vector3 Position;

        public CmdPlacePlantParameters(int level, Vector3 position)
        {
            Level = level;
            Position = position;
        }
    }
}

using MergePlants.Services.Command;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateLevelParameters : ICommandParameter
    {
        public readonly int LevelId;

        public CmdCreateLevelParameters(int levelId)
        {
            LevelId = levelId;
        }
    }
}

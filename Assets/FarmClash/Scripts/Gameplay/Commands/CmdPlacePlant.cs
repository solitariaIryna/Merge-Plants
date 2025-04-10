using FarmClash.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.State.Root;

namespace FarmClash.Gameplay.Commands
{
    public class CmdPlacePlant : ICommand<CmdPlacePlantParameters>
    {
        private readonly GameStateProxy _gameState;
        public bool Execute(CmdPlacePlantParameters parameters)
        {
            return true;
        }
    }
}

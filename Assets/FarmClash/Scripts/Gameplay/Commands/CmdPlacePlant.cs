using MergerPlants.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.State.Root;

namespace MergerPlants.Gameplay.Commands
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

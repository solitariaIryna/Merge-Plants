using MergePlants.Services.Command;
using MergePlants.State.Entities.Plants;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdDeletePlantParameters : ICommandParameter
    {
        public PlantEntity Plant;

        public CmdDeletePlantParameters(PlantEntity plant)
        {
            Plant = plant;
        }
    }
}

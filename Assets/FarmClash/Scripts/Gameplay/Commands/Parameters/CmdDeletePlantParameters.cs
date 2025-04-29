using MergePlants.Gameplay.Plants;
using MergePlants.Services.Command;

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

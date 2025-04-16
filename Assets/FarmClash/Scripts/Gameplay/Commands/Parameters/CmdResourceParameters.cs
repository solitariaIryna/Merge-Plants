using MergePlants.Services.Command;
using MergePlants.State.GameResources;

namespace MergerPlants.Gameplay.Commands.Parameters
{
    public class CmdResourceParameters : ICommandParameter
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;
        public CmdResourceParameters(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}

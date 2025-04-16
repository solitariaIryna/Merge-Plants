using MergePlants.Services.Command;
using MergePlants.State.GameResources;

namespace MergerPlants.Gameplay.Commands.Parameters
{
    public class CmdResourceSpendParameters : ICommandParameter
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;

        public CmdResourceSpendParameters(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}

using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.State.GameResources;
using MergePlants.State.Root;
using System.Linq;

namespace MergePlants.Gameplay.Commands
{
    public class CmdResourceAdd : ICommand<CmdResourceParameters>
    {
        private readonly GameStateProxy _gameState;
        public CmdResourceAdd(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        public bool Execute(CmdResourceParameters parameters)
        {
            ResourceType requiredResourceType = parameters.ResourceType;
            Resource requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            requiredResource ??= CreateNewResource(requiredResourceType);

            requiredResource.Amount.Value += parameters.Amount;

            return true;
        }

        private Resource CreateNewResource(ResourceType resourceType)
        {
            ResourceData newResourceData = new ResourceData
            {
                ResourceType = resourceType,
                Amount = 0
            };

            var newResource = new Resource(newResourceData);
            _gameState.Resources.Add(newResource);


            return newResource;
        }
    }
}

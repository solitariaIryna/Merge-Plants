using FarmClash.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.State.GameResources;
using MergePlants.State.Root;
using System.Linq;
using UnityEngine;

namespace FarmClash.Gameplay.Commands
{
    public class CmdResourceSpend : ICommand<CmdResourceSpendParameters>
    {
        private readonly GameStateProxy _gameState;

        public CmdResourceSpend(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        public bool Execute(CmdResourceSpendParameters parameters)
        {
            ResourceType requiredResourceType = parameters.ResourceType;
            Resource requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            if (requiredResource == null)
            {
                Debug.LogError("Trying to spend not existed resource");
                return false;
            }

            if (requiredResource.Amount.Value < parameters.Amount)
            {
                Debug.LogError(
                    $"Trying to spend more resources than existed ({requiredResourceType}). " +
                    $"Exists: {requiredResource.Amount.Value}, trying to spend: {parameters.Amount}");
                return false;
            }

            requiredResource.Amount.Value -= parameters.Amount;

            return true;
        }
    }
}

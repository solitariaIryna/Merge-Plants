using MergePlants.Services.SaveLoad;
using System;
using System.Collections.Generic;

namespace MergePlants.Services.Command
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<Type, object> _commands = new();

        private ISaveLoadService _saveLoadService;
        public CommandProcessor(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        public void RegisterCommand<TCommandParams>(ICommand<TCommandParams> command) where TCommandParams : ICommandParameter
        {
            _commands[typeof(TCommandParams)] = command;
        }
        public bool Process<TCommandParams>(TCommandParams comandParams) where TCommandParams : ICommandParameter
        {
            if (_commands.TryGetValue(typeof(TCommandParams), out var command))
            {
                var typedCommand = (ICommand<TCommandParams>)command;
                bool result = typedCommand.Execute(comandParams);

                if (result)
                    _saveLoadService.SaveGameState();

                return result;
            }

            return false;
        }
    }
}
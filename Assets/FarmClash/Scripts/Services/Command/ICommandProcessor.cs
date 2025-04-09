using System;
using System.Collections.Generic;

namespace FarmClash.Services.Command
{
    public interface ICommandProcessor
    {
        void RegisterCommand<TParameter>(ICommand<TParameter> command) where TParameter : ICommandParameter;
    }

    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<Type, object> _commands = new();
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

                return result;
            }

            return false;
        }
    }
}
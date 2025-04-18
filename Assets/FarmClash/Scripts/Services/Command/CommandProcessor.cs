﻿using MergePlants.Services.SaveLoad;
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
        public void RegisterCommand<TCommandParams, TResult>(ICommandWithResult<TCommandParams, TResult> command) where TCommandParams : ICommandParameter
        {
            _commands[typeof(TCommandParams)] = command;
        }
        public CommandResult<TResult> Process<TCommandParams, TResult>(TCommandParams comandParams) where TCommandParams : ICommandParameter
        {
            if (_commands.TryGetValue(typeof(TCommandParams), out var command))
            {
                var typedCommand = (ICommandWithResult<TCommandParams, TResult>)command;
                CommandResult<TResult> success = typedCommand.Execute(comandParams);

                if (success.Success)
                    _saveLoadService.SaveGameState();

                return success;
            }

            return new CommandResult<TResult>(false, default);
        }

        public bool Process<TCommandParams>(TCommandParams comandParams) where TCommandParams : ICommandParameter
        {
            if (_commands.TryGetValue(typeof(TCommandParams), out var command))
            {
                var typedCommand = (ICommand<TCommandParams>)command;
                bool success = typedCommand.Execute(comandParams);

                if (success)
                    _saveLoadService.SaveGameState();

                return success;
            }

            return false;
        }
    }
}
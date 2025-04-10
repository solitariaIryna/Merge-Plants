namespace MergePlants.Services.Command
{
    public interface ICommandProcessor
    {
        void RegisterCommand<TParameter>(ICommand<TParameter> command) where TParameter : ICommandParameter;
    }
}
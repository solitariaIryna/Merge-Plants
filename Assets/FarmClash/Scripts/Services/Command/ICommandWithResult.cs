namespace MergePlants.Services.Command
{
    public interface ICommandWithResult<TParams, TResult>
    {
        CommandResult<TResult> Execute(TParams parameters);
    }
}
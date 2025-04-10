
namespace MergePlants.Services.Command
{
    public interface ICommand<TParameter> where TParameter : ICommandParameter
    {
        bool Execute(TParameter parameters);
    }

}

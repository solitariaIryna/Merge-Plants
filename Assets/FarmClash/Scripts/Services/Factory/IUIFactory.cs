using MergePlants.UI;

namespace MergePlants.Services.Factory
{
    public interface IUIFactory
    {
        T CreateWindow<T>(string path) where T : BaseWindow;
    }
}
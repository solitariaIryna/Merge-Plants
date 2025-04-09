using FarmClash.UI;

namespace FarmClash.Services.Factory
{
    public interface IUIFactory
    {
        T CreateWindow<T>(string path) where T : BaseWindow;
    }
}
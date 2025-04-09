using FarmClash.UI;

namespace FarmClash.Services.Window
{
    public interface IWindowService
    {
        T OpenWindow<T>(WindowType id) where T : BaseWindow;
    }
}
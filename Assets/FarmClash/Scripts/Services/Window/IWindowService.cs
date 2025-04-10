using MergePlants.UI;

namespace MergePlants.Services.Window
{
    public interface IWindowService
    {
        T OpenWindow<T>(WindowType id) where T : BaseWindow;
    }
}
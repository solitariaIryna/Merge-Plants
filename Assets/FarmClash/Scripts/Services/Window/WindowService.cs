using MergePlants.Services.Factory;
using MergePlants.UI;
using System.Collections.Generic;
using UnityEngine;

namespace MergePlants.Services.Window
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uIFactory;

        private Dictionary<WindowType, string> _windowPaths;

        private List<BaseWindow> _openedWindows = new();
        public WindowService(IUIFactory uIFactory)
        {
            _uIFactory = uIFactory;

            _windowPaths = new Dictionary<WindowType, string>()
            {
                

            };
        }
        public void Dispose()
        {
            foreach (BaseWindow window in _openedWindows)
                window.Deactivate();

            _openedWindows.Clear();
        }

        public T OpenWindow<T>(WindowType id) where T : BaseWindow
        {
            T window = _uIFactory.CreateWindow<T>(GetWindowPath(id));
            _openedWindows.Add(window);
            return window;
        }
        private string GetWindowPath(WindowType id)
        {
            if (!_windowPaths.ContainsKey(id))
            {
                Debug.LogError($"AssetData not found for ID: {id}");
                return null;
            }

            return _windowPaths[id];
        }
    }
}

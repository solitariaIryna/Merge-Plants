using UnityEngine;

namespace MergePlants.Gameplay.View.Cells
{
    public class CellBinder : MonoBehaviour
    {
        private CellViewModel _viewModel;
        public void Bind(CellViewModel viewModel)
        {
            _viewModel = viewModel;

            transform.position = _viewModel.Position;
        }
    }
}

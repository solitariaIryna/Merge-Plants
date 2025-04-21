using UnityEngine;

namespace MergePlants.Gameplay.View.Enemies
{
    public class EnemyBinder : MonoBehaviour
    {
        [field: SerializeField] public EnemyVisual Visual { get; private set; }

        private EnemyViewModel _viewModel;
        public void Bind(EnemyViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}

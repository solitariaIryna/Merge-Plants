using UnityEngine;
using MergePlants.Gameplay.Enemies;

namespace MergePlants.UI
{
    public class HealthDisplayUI : MonoBehaviour
    {
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private EnemyEntity _enemy;

        private void Start()
        {
            _enemy.Damagable.Damaged += (_,_) => UpdateProgressBar();
        }
        private void UpdateProgressBar()
        {
            _progressBar.SetValue(_enemy.Damagable.HealthNormalized);
        }

    }
}

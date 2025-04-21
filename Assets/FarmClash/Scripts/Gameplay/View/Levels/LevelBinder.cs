using MergePlants.Configs.Enemies;
using UnityEngine;


namespace MergePlants.Gameplay.View.Levels
{
    public class LevelBinder : MonoBehaviour
    {
        [field: SerializeField] public Transform CellsParent { get; private set; }
        [SerializeField] private EnemiesSpawner _enemiesSpawmer;
        [SerializeField] private EnemiesWaveConfig _waveConfig;

        private LevelViewModel _viewModel;
        public void Bind(LevelViewModel levelViewModel)
        {
            _viewModel = levelViewModel;

            _enemiesSpawmer.StartSpawnEnemy(_waveConfig);
        }
    }

}

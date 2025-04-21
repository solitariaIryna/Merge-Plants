using MergePlants.Gameplay.Services;
using UnityEngine;
using Zenject;
using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.View.Levels;
using System.Collections;

namespace MergePlants.Gameplay
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private EnemyPath _enemyPath;

        private EnemiesService _enemiesService;
        private EnemiesWaveConfig _waveConfig;

        private bool _waveActive;

        [Inject]
        private void Construct(EnemiesService enemiesService)
        {
            _enemiesService = enemiesService;          
        }

        public void StartSpawnEnemy(EnemiesWaveConfig waveConfig)
        {
            _waveConfig = waveConfig;
            _waveActive = true;

            StartCoroutine(SpawningEnemy());
        }

        private IEnumerator SpawningEnemy()
        {
            while (_waveActive)
            {
                foreach (EnemiesQueque enemiesQueque in _waveConfig.EnemiesQueues)
                {
                    for (int i = 0; i < enemiesQueque.Count; i++)
                    {
                        yield return new WaitForSeconds(_waveConfig.SpawnDelay);
                        SpawnEnemy(enemiesQueque.EnemyType);
                    }
                    
                }
                _waveActive = false;
            }
        }
        public void SpawnEnemy(EnemyType enemyType)
        {
            _enemiesService.CreateEnemy(enemyType, _spawnPoint.position, _enemyPath);
        }
    }

}

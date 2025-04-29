using MergePlants.State.Entities.Enemies;
using UnityEngine;
using R3;
using System.Collections;

namespace MergePlants.UI
{
    public class EnemyActorUI : MonoBehaviour
    {
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private EnemyEntity _enemy;

        private void OnEnable()
        {
            StartCoroutine(Subscribe());
        }
        private IEnumerator Subscribe()
        {
            yield return new WaitForSeconds(1f);
            _enemy.Health.Current.Subscribe(current => UpdateProgressBar(current));
        }

        private void OnDisable() => 
            _enemy.Health.Current.Dispose();
        private void UpdateProgressBar(float current)
        {
            _progressBar.SetValue(current, _enemy.Health.Max);
        }

    }
}

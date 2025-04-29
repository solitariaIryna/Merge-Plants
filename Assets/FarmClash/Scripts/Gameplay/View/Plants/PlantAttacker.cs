using Cysharp.Threading.Tasks;
using MergePlants.Configs.Plants;
using MergePlants.Gameplay.Enemies;
using MergePlants.Gameplay.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace MergePlants.Gameplay.Plants
{
    public class PlantAttacker
    {
        private readonly BulletService _bulletService;
        private readonly Transform _attackPoint;

        private PlantConfig _config;
        private List<IDamagableTarget> _targets = new();
        private IDamagableTarget _currentTarget;

        private CancellationTokenSource _attackCts;

        public PlantAttacker(BulletService bulletService, Transform attackPoint)
        {
            _bulletService = bulletService;
            _attackPoint = attackPoint;
        }

        public void SetConfig(PlantConfig config)
        {
            _config = config;
        }

        public void StartAttacking(IDamagableTarget target)
        {
            if (_targets.Contains(target)) return;

            _targets.Add(target);
            target.Died += OnTargetDied;

            _currentTarget ??= target;

            if (_attackCts == null || _attackCts.IsCancellationRequested)
            {
                _attackCts = new CancellationTokenSource();
                AttackLoopAsync(_attackCts.Token).Forget();
            }
        }

        public void StopAttacking(IDamagableTarget target)
        {
            if (!_targets.Contains(target)) return;

            _targets.Remove(target);
            target.Died -= OnTargetDied;

            if (_currentTarget == target)
                _currentTarget = _targets.FirstOrDefault();

            if (_targets.Count == 0)
            {
                _attackCts?.Cancel();
                _attackCts = null;
            }
        }

        private void OnTargetDied(IDamagableTarget target)
        {
            StopAttacking(target);
        }

        private async UniTaskVoid AttackLoopAsync(CancellationToken token)
        {
            while (_targets.Count > 0 && !token.IsCancellationRequested)
            {
                if (_currentTarget != null && _currentTarget.Damagable.IsAlive)
                {
                    _bulletService.CreateBullet(_attackPoint.position, _currentTarget.Transform, _config.BulletSpeed, _config.Damage);
                    await UniTask.Delay(System.TimeSpan.FromSeconds(_config.AttackSpeed), cancellationToken: token);
                }
                else
                {
                    _currentTarget = _targets.FirstOrDefault();
                    await UniTask.Yield();
                }
            }
        }
    }

}

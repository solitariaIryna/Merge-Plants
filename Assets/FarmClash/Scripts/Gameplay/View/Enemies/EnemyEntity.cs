using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.View.Enemies;
using MergePlants.Gameplay.View.Levels;
using MergePlants.State.Entities.Enemies;
using MergePlants.State.Entities;
using System;
using UnityEngine;
using MergePlants.Gameplay.Ememies;

namespace MergePlants.Gameplay.Enemies
{
    public class EnemyEntity : Entity, IDamagableTarget
    {
        [field: SerializeField] public EnemyVisual Visual { get; private set; }
        public EnemyType EnemyType { get; private set; }

        public bool IsAlive => !_isDead;
        public Transform Transform => transform;
        public EnemyMover Mover => _mover;
        public IDamagable Damagable => _health;

        public Action Hit;

        private EnemyEntityData _data;
        private EnemyConfig _config;
        private EnemyMover _mover;
        private EntityHealth _health;
        private bool _isDead;

        public event Action<IDamagableTarget> Died;

        public void SetData(EnemyEntityData data)
        {
            base.SetData(data);
            _data = data;
            _health = new EntityHealth(data.Config.Config.Health, data.Config.Config.Health);
            EnemyType = data.EnemyType;
            _config = data.Config.Config;

            transform.position = data.Position;
            Visual.Construct(data.Config.VisualConfig);

            _health.Died += OnDied;
        }
        public void SetPath(EnemyPath path)
        {
            _mover = new EnemyMover(transform, path, _config.MoveSpeed);
        }

        private void Update()
        {
            _mover?.Move();
        }

        private void OnDied(IDamagable damagable)
        {
            if (_isDead) return;

            Died?.Invoke(this);
            Destroy(gameObject, 0.5f);
        }
    }
}


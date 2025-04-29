using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.View.Enemies;
using MergePlants.Gameplay.View.Levels;
using R3;
using System;
using UnityEngine;

namespace MergePlants.State.Entities.Enemies
{
    public class EnemyEntity : Entity, IDamagable
    {
        [field: SerializeField] public EnemyVisual Visual { get; private set; }
        public EnemyType EnemyType { get; private set; }

        private EnemyPath _path;

        private EnemyConfig _config;
        public float Velocity { get; private set; }

        public Transform Transform => transform;

        private EnemyEntityData _enemyData;
        public bool IsAlive => !_isDied;

        public Stat<float> Health => _enemyData.Health;


        public Action Died;
        public Action Hit;
        private int _index;

        private bool _canMove = true;
        private bool _isDied;
        public void SetData(EnemyEntityData data)
        {
            base.SetData(data);
            _enemyData = data;
            EnemyType = data.EnemyType;
            _config = data.Config.Config;

            Visual.Construct(data.Config.VisualConfig);

            transform.position = data.Position;
        }

        public void SetPath(EnemyPath enemyPath)
        {
            _path = enemyPath;
        }

        private void Update()
        {
            if (!_canMove)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _path.GetPoint(_index), _config.MoveSpeed * Time.deltaTime);
            Velocity = 1;

            if (Vector3.Distance(transform.position, _path.GetPoint(_index)) < 0.1f)
            {
                _index++;
            }
        }

        public void TakeDamage(float damage)
        {
            _enemyData.Health.Current.Value -= damage;
            Hit?.Invoke();

            if (_enemyData.Health.Current.Value <= 0)
                Die();
        }

        private void Die()
        {
            if (_isDied)
                return;

            _isDied = true;
            _canMove = false;
            Died?.Invoke();
            Destroy(gameObject, 0.5f);
        }
    }
}

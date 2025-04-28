using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.View.Enemies;
using MergePlants.Gameplay.View.Levels;
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

        public bool IsAlive => true;

        private Vector3 _lastPosition;

        private int _index;
        public void SetData(EnemyEntityData data)
        {
            base.SetData(data);
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
            transform.position = Vector3.MoveTowards(transform.position, _path.GetPoint(_index), _config.MoveSpeed * Time.deltaTime);
            Velocity = 1;
            _lastPosition = transform.position;

            if (Vector3.Distance(transform.position, _path.GetPoint(_index)) < 0.1f)
            {
                _index++;
            }
        }

        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}

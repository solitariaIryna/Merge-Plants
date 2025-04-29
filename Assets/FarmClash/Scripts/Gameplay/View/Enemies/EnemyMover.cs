using MergePlants.Gameplay.View.Levels;
using UnityEngine;

namespace MergePlants.Gameplay.Ememies
{
    public class EnemyMover
    {
        private readonly Transform _transform;
        private readonly EnemyPath _path;
        private readonly float _speed;

        private int _index;

        public Vector3 Velocity { get; private set; } 

        public EnemyMover(Transform transform, EnemyPath path, float speed)
        {
            _transform = transform;
            _path = path;
            _speed = speed;
        }

        public void Move()
        {
            if (_index >= _path.PointsCount)
            {
                Velocity = Vector3.zero;
                return;
            }

            Vector3 target = _path.GetPoint(_index);
            Vector3 newPosition = Vector3.MoveTowards(_transform.position, target, _speed * Time.deltaTime);

            Velocity = (newPosition - _transform.position) / Time.deltaTime;

            _transform.position = newPosition;

            if (Vector3.Distance(_transform.position, target) < 0.1f)
            {
                _index++;
            }
        }
    }
}

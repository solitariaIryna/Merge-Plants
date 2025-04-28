using MergePlants.State.Entities;
using MergePlants.State.Entities.Bullets;
using System.Collections;
using UnityEngine;

namespace MergePlants.Gameplay.View.Bullets
{
    public class BulletEntity : Entity
    {
        [SerializeField] private float _speed = 0.3f;

        private Transform _target;

        public void SetData(BulletEntityData data)
        {
            _target = data.Target;
            transform.position = data.Position;
        }
        public void StartForce()
        {
            StartCoroutine(Force());
        }
        private IEnumerator Force()
        {
            while (_target != null && Vector2.Distance(transform.position, _target.position) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
                yield return null;
            }
            Destroy(gameObject);
        }

    }
}

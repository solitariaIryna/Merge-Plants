using MergePlants.Gameplay.Core;
using MergePlants.State.Entities;
using MergePlants.State.Entities.Bullets;
using System.Collections;
using UnityEngine;

namespace MergePlants.Gameplay.View.Bullets
{
    public class BulletEntity : Entity
    {
        private Transform _target;

        private BulletEntityData _bulletData;

        public void SetData(BulletEntityData data)
        {
            base.SetData(data);
            _bulletData = data;
            _target = data.Target;
            transform.position = data.Position;
        }
        public void StartForce()
        {
            StartCoroutine(Force());
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamagable damagableTarget))
            {
                damagableTarget.TakeDamage(_bulletData.Damage);
                Destroy(gameObject);
            }
        }
        private IEnumerator Force()
        {
            while (_target != null && Vector2.Distance(transform.position, _target.position) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _bulletData.Speed * Time.deltaTime);
                yield return null;
            }

           
        }

    }
}

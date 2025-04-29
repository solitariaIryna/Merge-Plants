using MergePlants.Gameplay.Core;
using System;
using UnityEngine;

namespace MergePlants.Gameplay.Enemies
{
    public class EntityHealth : IDamagable
    {
        private float _currentHealth;
        private float _maxHealth;

        public event Action<IDamagable, float> Damaged;
        public event Action<IDamagable, float> Healed;
        public event Action<IDamagable> Died;

        public float Health => _currentHealth;
        public float HealthNormalized => Mathf.Clamp01((float)_currentHealth / _maxHealth);

        public bool IsAlive => _currentHealth > 0;
        public EntityHealth(float current, float max)
        {
            _currentHealth = current;
            _maxHealth = max;
        }

        public void ApplyDamage(float damage)
        {
            if (!IsAlive)
                return;

            _currentHealth -= damage;

            if (_currentHealth < 0)
                _currentHealth = 0;

            Damaged?.Invoke(this, damage);

            if (_currentHealth <= 0)
                Died?.Invoke(this);
            
        }

        public void ApplyHealling(float healAmount)
        {
            if (!IsAlive || healAmount == 0)
                return;

            float oldHealhAmount = _currentHealth;

            _currentHealth += healAmount;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            float actualHealAmount = _currentHealth - oldHealhAmount;

            Healed?.Invoke(this, actualHealAmount);
        }
    }
}


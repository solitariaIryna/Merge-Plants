
using UnityEngine;

namespace MergePlants.Gameplay.Core
{
    public interface IDamagable
    {
        Transform Transform { get; }
        bool IsAlive { get; }
        void TakeDamage(float damage);
    }
}

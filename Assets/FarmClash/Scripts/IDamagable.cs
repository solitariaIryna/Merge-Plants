using System;

namespace MergePlants.Gameplay.Core
{
    public interface IDamagable
    {
        event Action<IDamagable, float> Damaged;
        event Action<IDamagable, float> Healed;
        event Action<IDamagable> Died;

        float Health { get; }
        float HealthNormalized { get; }
        bool IsAlive { get; }
        void ApplyDamage(float damage);
        void ApplyHealling(float healAmount);
    }
}

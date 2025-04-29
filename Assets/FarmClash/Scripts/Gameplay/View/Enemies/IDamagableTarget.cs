using MergePlants.Gameplay.Core;
using System;
using UnityEngine;

namespace MergePlants.Gameplay.Enemies
{
    public interface IDamagableTarget
    {
        Transform Transform { get; }
        IDamagable Damagable { get; }
        event Action<IDamagableTarget> Died;
    }
}


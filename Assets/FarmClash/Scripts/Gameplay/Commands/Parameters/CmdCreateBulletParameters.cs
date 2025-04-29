using MergePlants.Services.Command;
using UnityEngine;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateBulletParameters : ICommandParameter
    {
        public readonly Vector3 Position;
        public readonly Transform Target;
        public readonly float Speed;
        public readonly float Damage;

        public CmdCreateBulletParameters(Vector3 position, Transform target, float speed, float damage)
        {
            Position = position;
            Target = target;
            Speed = speed;
            Damage = damage;
        }
    }
}

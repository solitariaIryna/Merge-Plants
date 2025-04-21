using MergePlants.Services.Command;
using UnityEngine;
using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.View.Levels;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateEnemyParameters : ICommandParameter
    {
        public readonly EnemyType EnemyType;
        public readonly Vector3 Position;
        public readonly EnemyPath EnemyPath;

        public CmdCreateEnemyParameters(EnemyType enemyType, Vector3 position, EnemyPath enemyPath)
        {
            EnemyType = enemyType;
            Position = position;
            EnemyPath = enemyPath;
        }
    }
}

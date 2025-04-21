using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.View.Levels;

namespace MergePlants.State.Entities.Enemies
{
    public class EnemyEntity : Entity
    {
        public EnemyType EnemyType { get; private set; }

        private EnemyPath _path;
        public EnemyEntity(EnemyEntityData data, EnemyPath path) : base(data)
        {
            EnemyType = data.EnemyType;
            _path = path;
        }
    }
}

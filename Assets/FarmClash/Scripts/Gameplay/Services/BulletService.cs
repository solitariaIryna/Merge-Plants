using MergePlants.Services.Command;
using UnityEngine;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Gameplay.View.Bullets;

namespace MergePlants.Gameplay.Services
{
    public class BulletService
    {
        private readonly ICommandProcessor _cmd;

        public BulletService(ICommandProcessor cmd)
        {
            _cmd = cmd;
        }

        public bool CreateBullet(Vector3 position, Transform target)
        {
            var parameters = new CmdCreateBulletParameters(position, target);
            CommandResult<BulletEntity> result = _cmd.Process<CmdCreateBulletParameters, BulletEntity>(parameters);

            if (result.Success)
            {
                BulletEntity bullet = result.Result;
                bullet.StartForce();
            }

            return result.Success;
        }
    }
}

using FarnClash.Infrastructure.Game.Factory;
using FarnClash.Infrastructure.StateMachine;
using Unity.Cinemachine;
using UnityEngine;

namespace FarnClash.Infrastructure.Gameplay.StatesMachine
{
    public class LoadBattleState : IState
    {
        private readonly GameFactory _gameFactory;

        public LoadBattleState(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            CinemachineCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineCamera>();
        }

        public void Exit()
        {

        }
    }        
}

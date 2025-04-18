using System;
using UnityEngine;


namespace MergePlants.Gameplay.View.Levels
{
    public class LevelBinder : MonoBehaviour
    {
        [field: SerializeField] public Transform CellsParent { get; private set; }
        [SerializeField] private EnemyPath _enemyPath;

        public void Bind(LevelViewModel levelViewModel)
        {
            
        }
    }

}

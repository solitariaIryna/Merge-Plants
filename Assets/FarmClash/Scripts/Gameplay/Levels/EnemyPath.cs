using UnityEngine;
using UnityEngine.Splines;


namespace MergePlants.Gameplay.Levels
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField] private SplineContainer _splineContainer;

        public Vector3 EvaluatePosition(int splineIndex, float t) => 
            transform.TransformPoint(_splineContainer.Spline.EvaluatePosition(t));
        public Vector3 EvaluateTangent(int splineIndex, float t) => 
            _splineContainer.Spline.EvaluateTangent(t);
    }
}

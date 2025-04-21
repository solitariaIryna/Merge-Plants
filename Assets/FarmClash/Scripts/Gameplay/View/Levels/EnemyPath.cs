using UnityEngine;
using UnityEngine.Splines;


namespace MergePlants.Gameplay.View.Levels
{
    public class EnemyPath : MonoBehaviour
    {

        [SerializeField] private Transform[] _points;

        public Vector3 GetPoint(int index) => _points[index].position;
        //[SerializeField] private SplineContainer _splineContainer;

        //public Vector3 EvaluatePosition(int splineIndex, float t) => 
        //    transform.TransformPoint(_splineContainer.Spline.EvaluatePosition(t));
        //public Vector3 EvaluateTangent(int splineIndex, float t) => 
        //    _splineContainer.Spline.EvaluateTangent(t);
    }
}

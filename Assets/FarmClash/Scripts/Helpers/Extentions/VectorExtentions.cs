using UnityEngine;
using Random = UnityEngine.Random;
namespace FarmClash.Helpers.Extentions
{
    public static class VectorExtentions
    {
        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
        {
            return Quaternion.Euler(angles) * (point - pivot) + pivot;
        }

        public static float SqrDistance2D(Vector2 a, Vector2 b)
        {
            float xDelta = a.x - b.x;
            float yDelta = a.y - b.y;

            return xDelta * xDelta + yDelta * yDelta;
        }

        public static float SqrDistance3D(Vector3 a, Vector3 b)
        {
            float xDelta = a.x - b.x;
            float yDelta = a.y - b.y;
            float zDelta = a.z - b.z;

            return xDelta * xDelta + yDelta * yDelta + zDelta * zDelta;
        }

        public static bool SqrDistanceBetweenLessThen(Vector2 a, Vector2 b, float sqrDistance)
        {
            float xDelta = a.x - b.x;
            float yDelta = a.y - b.y;

            float sqrDistanceBetween = xDelta * xDelta + yDelta * yDelta;

            return sqrDistanceBetween < sqrDistance;
        }

        public static float Distance2D(Vector2 a, Vector2 b)
        {
            float xDelta = a.x - b.x;
            float yDelta = a.y - b.y;

            return Mathf.Sqrt(xDelta * xDelta + yDelta * yDelta);
        }

        public static Vector3 Vector3FromSingleNumber(float number)
        {
            return new Vector3(number, number, number);
        }

        public static float AsRangeRandomValue(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }

        public static int AsRangeRandomValue(this Vector2Int range)
        {
            return Random.Range(range.x, range.y);
        }
    }


}

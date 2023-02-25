using UnityEngine;

class DirectionVectorCreator : MonoBehaviour
{
    [SerializeField] Vector3 point1, point2;
Vector3 DirectionFromAToB(Vector3 a, Vector3 b)
    {
        return (b - a).normalized;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point1, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(point2, 0.1f);

        Vector3 dir = DirectionFromAToB(point1, point2);

        Vector3 c = point1 + dir;

        Gizmos.DrawLine(point1, c);
    }
}


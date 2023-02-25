using UnityEngine;

class StepJumper : MonoBehaviour
{
    [SerializeField] Vector2 a, b;
    [SerializeField] int stepCount;
    [SerializeField] Vector2 step;

    void OnValidate() // onvalidate háttérben fut le, fejlesztõi eszköz
    {
        Vector2 v = b - a;

        float lenght = v.magnitude;
        stepCount = Mathf.CeilToInt(lenght);

        step = v / stepCount;
    }



}

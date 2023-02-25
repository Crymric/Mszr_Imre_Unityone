using UnityEngine;

class StepJumper : MonoBehaviour
{
    [SerializeField] Vector2 a, b;
    [SerializeField] int stepCount;
    [SerializeField] Vector2 step;

    void OnValidate() // onvalidate h�tt�rben fut le, fejleszt�i eszk�z
    {
        Vector2 v = b - a;

        float lenght = v.magnitude;
        stepCount = Mathf.CeilToInt(lenght);

        step = v / stepCount;
    }



}

using Unity.VisualScripting;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Light light;

    [SerializeField] Color color1, color2;
    [SerializeField] float frequency = 1;
    void Update()
    {
        float t = Mathf.Sin(Time.time * 2 * Mathf.PI);
        t += 1; // sinus már 2 és 1 között fog mozogni és nem 1 és -1 között
        t /= 2; // osztom kettõvel és már 0 és 1 között fog mozogni a sinus

        Color c = Color.Lerp(color1, color2, t);  //Lerp interpolciós függvény

        light.color = c;
    }
}

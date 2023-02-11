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
        t += 1; // sinus m�r 2 �s 1 k�z�tt fog mozogni �s nem 1 �s -1 k�z�tt
        t /= 2; // osztom kett�vel �s m�r 0 �s 1 k�z�tt fog mozogni a sinus

        Color c = Color.Lerp(color1, color2, t);  //Lerp interpolci�s f�ggv�ny

        light.color = c;
    }
}

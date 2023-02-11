using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField] float angularSpeed = 180;
        void Update()
    {
        transform.Rotate(0 , angularSpeed * Time.deltaTime, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed; // komponensk�nt megjelenik unityben
    [SerializeField] float angularSpeed = 180; // komponensk�nt megjelenik unityben

    [SerializeField] Transform cameraTransform;


    Quaternion targetRotation;
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        float x = 0;     // "helytelen" a jobb nyil fel�l fogja �rni a balt
        if (right)
            x = 1;
        else if (left)
            x = -1;

        float z = 0;  // "helyes" az egyik ir�ny meg�ll�tja a m�sikat
        if (up)
            z += 1;
        if (down)
            z -= 1;

        Vector3 rightDir = cameraTransform.right;
        Vector3 forwardDir = cameraTransform.forward;
        Vector3 direction = (rightDir * x) + (forwardDir * z);

        direction.y = 0;

        direction.Normalize(); // sr�hen gyorsabban mozog, ha ez nincs benne
        
        Transform t = transform; //lek�rem a game object transform komponens�t �s beletettem a t v�ltoz�ba

        // Quaternion rot = t.rotation;


        Vector3 pos = t.position; // megadja, hogy hol van a t�rben az objektum

        Vector3 velocity = direction * speed;

        //Vector3 velocity = new Vector3(1 , 0, 0);
        pos += velocity * Time.deltaTime; // el�z� k�pfriss�t�s �ta eltelt id� a Time.deltaTime

        t.position = pos;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            t.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
        }
        // t.position = new Vector3(0, 5, 0); //k�pfriss�t�senk�nt erre a pontra rakja
    }
}

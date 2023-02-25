using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed; // komponensként megjelenik unityben
    [SerializeField] float angularSpeed = 180; // komponensként megjelenik unityben

    [SerializeField] Transform cameraTransform;


    Quaternion targetRotation;
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        float x = 0;     // "helytelen" a jobb nyil felül fogja írni a balt
        if (right)
            x = 1;
        else if (left)
            x = -1;

        float z = 0;  // "helyes" az egyik irány megállítja a másikat
        if (up)
            z += 1;
        if (down)
            z -= 1;

        Vector3 rightDir = cameraTransform.right;
        Vector3 forwardDir = cameraTransform.forward;
        Vector3 direction = (rightDir * x) + (forwardDir * z);

        direction.y = 0;

        direction.Normalize(); // sréhen gyorsabban mozog, ha ez nincs benne
        
        Transform t = transform; //lekérem a game object transform komponensét és beletettem a t változóba

        // Quaternion rot = t.rotation;


        Vector3 pos = t.position; // megadja, hogy hol van a térben az objektum

        Vector3 velocity = direction * speed;

        //Vector3 velocity = new Vector3(1 , 0, 0);
        pos += velocity * Time.deltaTime; // elõzõ képfrissítés óta eltelt idõ a Time.deltaTime

        t.position = pos;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            t.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
        }
        // t.position = new Vector3(0, 5, 0); //képfrissítésenként erre a pontra rakja
    }
}

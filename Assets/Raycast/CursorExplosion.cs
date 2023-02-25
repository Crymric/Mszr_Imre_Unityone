using UnityEngine;

class CursorExplosion : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Transform cursor3D;

    void OnValidate()
    {
        camera = Camera.main;
    }


    void Update()
    {
        Vector3 v = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(v);

        bool doHit = Physics.Raycast(ray, out RaycastHit hit);


        if (doHit)
        {
            Debug.Log(hit.collider.name);
            cursor3D.position = hit.point;
        }
    }
}

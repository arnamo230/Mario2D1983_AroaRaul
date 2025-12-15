using UnityEngine;

public class CambiarLado : MonoBehaviour
{
    private float izquierda;
    private float derecha;
    private float objectWidth;

    void Start()
    {
        Camera cam = Camera.main;

        
        float screenHalfWidth = cam.orthographicSize * cam.aspect;
        izquierda = cam.transform.position.x - screenHalfWidth;
        derecha = cam.transform.position.x + screenHalfWidth;

        
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        
        if (pos.x > derecha + objectWidth)
        {
            pos.x = izquierda - objectWidth;
        }
        
        else if (pos.x < izquierda - objectWidth)
        {
            pos.x = derecha + objectWidth;
        }

        transform.position = pos;
    }
}

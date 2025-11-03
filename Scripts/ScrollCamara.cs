using UnityEngine;

public class ScrollCamaraTeoria : MonoBehaviour
{
    
    public Transform fondoActual; 
    public Transform fondoAuxiliar;
    public float spriteWidth = 20f; 
    public Camera camara; 
    private float cameraWidth; 
    private Transform temp;

    void Start()
    {
        
        if (camara == null)
        {
            camara = Camera.main;
        }

        
        cameraWidth = camara.orthographicSize * camara.aspect;

       
        fondoAuxiliar.position = new Vector3(
            fondoActual.position.x + spriteWidth,
            fondoActual.position.y,
            fondoActual.position.z
        );
    }

    void Update()
    {
        
        cameraWidth = camara.orthographicSize * camara.aspect;

        
        float pos_camera_x = camara.transform.position.x;
        float pos_fondoA_x = fondoActual.position.x;


        
        if (pos_camera_x + cameraWidth > pos_fondoA_x + (spriteWidth / 2f))
        {
           
            fondoActual.position = new Vector3(
                fondoAuxiliar.position.x + spriteWidth, 
                fondoActual.position.y,
                fondoActual.position.z
            );

            // Intercambiamos los roles
            temp = fondoActual;
            fondoActual = fondoAuxiliar;
            fondoAuxiliar = temp;
        }

       
        else if (pos_camera_x - cameraWidth < pos_fondoA_x - (spriteWidth / 2f))
        {
            fondoAuxiliar.position = new Vector3(
                fondoActual.position.x - spriteWidth,
                fondoAuxiliar.position.y,
                fondoAuxiliar.position.z
            );

            temp = fondoAuxiliar;
            fondoAuxiliar = fondoActual;
            fondoActual = temp;
        }
    }
}
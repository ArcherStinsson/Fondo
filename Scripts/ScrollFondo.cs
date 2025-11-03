using UnityEngine;

public class ScrollFondoTilemap : MonoBehaviour
{
   
    public Transform fondoActual;
    public Transform fondoAuxiliar;
    public float spriteWidth = 20f; 
    private float posxini;
    private Transform temp;

  
    public float velocidadScroll = 5f;

    void Start()
    {
        
        posxini = fondoActual.position.x;

        
        fondoAuxiliar.position = new Vector3(
            fondoActual.position.x + spriteWidth,
            fondoActual.position.y,
            fondoActual.position.z
        );
    }

    void Update()
    {
       
        fondoActual.Translate(Vector3.left * velocidadScroll * Time.deltaTime);
        fondoAuxiliar.Translate(Vector3.left * velocidadScroll * Time.deltaTime);

     
        if (fondoActual.position.x < posxini - (spriteWidth / 2f))
        {
           
            fondoActual.position = new Vector3(
                fondoAuxiliar.position.x + spriteWidth,
                fondoActual.position.y,
                fondoActual.position.z
            );

          
            temp = fondoActual;
            fondoActual = fondoAuxiliar;
            fondoAuxiliar = temp;
        }
    }
}

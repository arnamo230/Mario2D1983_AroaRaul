using UnityEngine;

public class Daño : MonoBehaviour
{
    [SerializeField] private float grosor = 1.5f; 
    [SerializeField] private LayerMask capaEnemigos;
    public Enemigo enemigo; 
 

    void OnCollisionEnter2D(Collision2D collision)
    {
    
            

             
            if (collision.gameObject.CompareTag("Ground"))
            {
                foreach (ContactPoint2D contacto in collision.contacts)
                {
                   
                    Debug.DrawRay(contacto.point, contacto.normal, Color.red, 1f);

                     
                    if (contacto.normal.y < -0.5f) 
                    {
                        GolpearEnemigoArriba(contacto.point);
                        break; 
                    }
                }
            }
        
    }
    
    private void GolpearEnemigoArriba(Vector2 puntoGolpe)
    {
       
       Vector2 origenRayo = puntoGolpe + (Vector2.up * 0.1f);
       Vector2 origen = puntoGolpe + (Vector2.up * 0.1f);
       Vector2 direccion = Vector2.up; 
       float distancia = grosor;

       
       RaycastHit2D hit = Physics2D.Raycast(origenRayo, Vector2.up, grosor, capaEnemigos);

      
       Debug.DrawLine(puntoGolpe, origenRayo, Color.red, 2f); 
       Debug.DrawRay(origenRayo, Vector2.up * grosor, Color.green, 2f); 

       if (hit.collider != null)
       {
          

           
        
           if (enemigo != null)
           {
               enemigo.RecibirGolpeDesdeAbajo();
           }
           
       }
       
       Color colorRayo;

       if (hit.collider != null)
       {
           colorRayo = Color.green;
       }
       else
       {
           colorRayo = Color.red;   
       }

       
       Debug.DrawRay(origen, direccion * distancia, colorRayo, 2.0f);
      
       if (hit.collider != null)
       {
           Enemigo enemigo = hit.collider.GetComponent<Enemigo>();
           if (enemigo != null)
           {
               enemigo.RecibirGolpeDesdeAbajo();
           }
       }
    }
}

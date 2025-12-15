using UnityEngine;

public class TuberiaTeletransportador : MonoBehaviour
{
    public Transform destino; 
    
    
    public float direccionSalida = 1f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy")) 
        {
    
            other.transform.position = destino.position;

           
            Enemigo scriptEnemigo = other.GetComponent<Enemigo>();
            if (scriptEnemigo != null)
            {
                scriptEnemigo.ConfigurarInicio(direccionSalida);
                
                
            }
        }
    }
}

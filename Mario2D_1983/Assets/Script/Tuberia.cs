using UnityEngine;

public class Tuberia : MonoBehaviour
{
    public Transform salida;

    public float direccionSalida = 1f;
   
    public void Spawnear(GameObject prefabEnemigo)
    {
        
        GameObject nuevoEnemigo = Instantiate(prefabEnemigo, salida.position, Quaternion.identity);

      
        nuevoEnemigo.name = prefabEnemigo.name;

       
        Enemigo scriptEnemigo = nuevoEnemigo.GetComponent<Enemigo>();
        
        if (scriptEnemigo != null)
        {
            
            scriptEnemigo.ConfigurarInicio(direccionSalida);
        }
    }
}

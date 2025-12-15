using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject prefabEnemigo;   
    public Tuberia[] tuberias;            
    public float tiempoEntreSpawn = 3f; 
    public int maxEnemigosSimultaneos = 4; 
    public int enemigosEnRondaInicial = 3; 
    private int enemigosTotalesEstaRonda;   
    private int rondaActual = 1;

    private int enemigosVivos = 0;

   void Start()
    {
        
        enemigosTotalesEstaRonda = enemigosEnRondaInicial;
        StartCoroutine(SistemaDeRondas());
    }

    IEnumerator SistemaDeRondas()
    {
       
        yield return new WaitForSeconds(2f);

        while (true) 
        {
           

           
            int enemigosGenerados = 0;

           
            while (enemigosGenerados < enemigosTotalesEstaRonda)
            {
                
                int enemigosEnPantalla = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if (enemigosEnPantalla < maxEnemigosSimultaneos)
                {
                    SpawnEnemigo();
                    enemigosGenerados++; 
                    yield return new WaitForSeconds(tiempoEntreSpawn);
                }
                else
                {
                   
                    yield return new WaitForSeconds(1f);
                }
            }

           
            

           
            while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                yield return new WaitForSeconds(1f);
            }

         
            
            
            yield return new WaitForSeconds(3f); 

           
            rondaActual++;
            enemigosTotalesEstaRonda++; 
            
           
            if(tiempoEntreSpawn > 0.5f) tiempoEntreSpawn -= 0.1f;
        }
    }

    void SpawnEnemigo()
    {
        
        int indice = Random.Range(0, tuberias.Length);
        tuberias[indice].Spawnear(prefabEnemigo);
    }
}

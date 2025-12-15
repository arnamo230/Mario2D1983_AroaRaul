using UnityEngine;
using System.Collections;

public class SaludJugador : MonoBehaviour
{
    [SerializeField] private int vida = 1;
    [SerializeField] private float tiempoInvencible = 5f;

    private bool esInvencible = false;

    public void Start()
    {
        esInvencible = false;
    }

    public void RecibirDaño(int daño)
    {
        if (esInvencible) return; 

        vida -= daño;
        Debug.Log("Vida del Player: " + vida);

        if (vida <= 0)
        {
            Morir();
            return;
        }

        
    }

   

    private void Morir()
    {
       
        Destroy(gameObject);
    }
}

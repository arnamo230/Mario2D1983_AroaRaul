using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    [SerializeField] private int daño = 1;
    public Enemigo enemigo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SaludJugador player = collision.gameObject.GetComponent<SaludJugador>();

            if (player != null && enemigo.estaAturdido == false)
            {
                player.RecibirDaño(daño);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float tiempoAturdimiento = 5f;
    public bool estaAturdido;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        

        estaAturdido = false;
    }

    private void FixedUpdate()
    {
        
        if (!estaAturdido)
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
        }
        else
        {
            
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    
    public void RecibirGolpeDesdeAbajo()
    {
        
        if (estaAturdido) return; 

        estaAturdido = true;
        
        
        spriteRenderer.flipY = true;

      
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        
        StartCoroutine(RutinaRecuperacion());
    }
    private IEnumerator RutinaRecuperacion()
    {
       
        yield return new WaitForSeconds(tiempoAturdimiento);

        
        if (gameObject != null) 
        {
            estaAturdido = false;
            spriteRenderer.flipY = false; 
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (estaAturdido)
            {
               
                Morir();
            }
           
        }
    }

    public void Morir()
    {
       
        
        Destroy(gameObject);
    }
    
   
    public bool IsStunned()
    {
        return estaAturdido;
    }
    
    public void ConfigurarInicio(float direccionInicial)
    {
       
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    
        velocidad = Mathf.Abs(velocidad) * direccionInicial;
    
        
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = (direccionInicial < 0);
        }
    }
}

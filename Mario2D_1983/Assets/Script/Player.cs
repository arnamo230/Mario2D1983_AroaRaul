using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
   private Vector2 moveInput;
    Rigidbody2D rb;
    
    
    
    [SerializeField]private int caida = 1;
    [SerializeField]private int bajada = 3;
   [SerializeField] private float salto = 0.5f;
    
   
     [SerializeField] private float veloacidad = 5.0f;
    [SerializeField] private float fuerzaSalto = 5.0f;
 
    [SerializeField] private float duracionCoyoteTime = 0.2f; 
    private float contadorCoyoteTime; 
   
    [SerializeField] private bool isGrounded;
   
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private LayerMask capaSuelo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
        if (isGrounded)
        {
           
            contadorCoyoteTime = duracionCoyoteTime;
        }
        else
        {
            
            contadorCoyoteTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radioDeteccion, capaSuelo);
        rb.linearVelocity = new Vector2(moveInput.x * veloacidad, rb.linearVelocity.y);
        
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = bajada;
        }
        else
        {
            rb.gravityScale = caida;
        }

        if (moveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1, 1);
        }
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && contadorCoyoteTime > 0f) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            
            
            contadorCoyoteTime = 0f; 
        }
        if (context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * salto);
            contadorCoyoteTime = 0f;
        }
    }

   
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

   
    
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.hotPink;
            Gizmos.DrawWireSphere(groundCheck.position, radioDeteccion);
        }
    }
}

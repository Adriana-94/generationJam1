using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Parámetros configurables
    [Header("Movimiento")]
    public float speed = 5.0f;
    public float jumpForce = 7.0f;

    [Header("Detección de Suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    // Componentes privados
    private Rigidbody2D playerRb;
    private bool isOnGround;

    void Start()
    {
        // Asignar el Rigidbody2D del jugador
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    // Controla el movimiento horizontal del jugador
    void HandleMovement()
    {
        float movementPlayer = Input.GetAxis("Horizontal");
        
        // Aplicar la velocidad horizontal sin afectar la velocidad vertical
        playerRb.velocity = new Vector2(movementPlayer * speed, playerRb.velocity.y);

        // Voltear el sprite si el personaje cambia de dirección
        if (movementPlayer != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementPlayer), 1, 1);
        }
    }

    // Controla el salto del jugador
    void HandleJump()
    {
        // Comprobar si el personaje está en el suelo
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Saltar si se presiona espacio y está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Dibuja el círculo de detección del suelo en la vista de escena
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

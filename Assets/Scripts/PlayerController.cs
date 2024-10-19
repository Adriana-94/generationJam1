using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float speed = 3.0f;         // Velocidad horizontal
    float jumpForce = 6.0f;    // Fuerza de salto
    bool isGround = false; 

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();  // Controlar el movimiento horizontal en cada frame de física
    }


    void Jump()
    {
        // Detectar el salto y aplicarlo solo si el personaje está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);  // Saltar verticalmente
            isGround = false;  // Ya no está en el suelo
        }
    }

    void Movement()
    {
        // Obtener la entrada horizontal (-1 para izquierda, 1 para derecha, 0 para no moverse)
        float getX = Input.GetAxis("Horizontal");

        // Aplicar movimiento horizontal constante con la dirección obtenida de las teclas de flecha
        rigidBody.velocity = new Vector2(getX * speed, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el personaje toca el suelo para permitir que vuelva a saltar
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}






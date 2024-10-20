using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D
    }

    void FixedUpdate()
    {
        // Movimiento hacia la derecha o izquierda
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); // Mover hacia la derecha
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); // Mover hacia la izquierda
        }
    }

    // Cambiar de dirección al tocar un Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit")) // Verificar si el enemigo ha tocado un límite
        {
            Flip();
        }
    }

    // Método para voltear la dirección
    void Flip()
    {
        movingRight = !movingRight; // Cambiar la dirección
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Invertir el sprite horizontalmente
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grabbable"))
        {
            Destroy(gameObject);
        }
    }


}

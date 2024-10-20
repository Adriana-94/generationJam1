using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float speed = 3.0f;         // Velocidad horizontal
    float jumpForce = 4.0f;    // Fuerza de salto
    bool isGround = false;


    // Agarrar cosas
    public float throwForce = 0.2f;  // Reduce la fuerza a un valor más bajo
    private GameObject objectToGrab; // Objeto que se puede agarrar
    private bool isHolding = false;  // Estado de si el jugador está sosteniendo un objeto
    private Transform grabPoint;     // Lugar donde el objeto será "pegado" cuando se agarre

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        grabPoint = transform.Find("GrabPoint"); // Poner el punto de agarre como hijo del personaje

    }

    private void Update()
    {
        Jump();


        // Si el jugador presiona el botón de agarrar (ejemplo, tecla 'E') y está cerca de un objeto
        if (Input.GetKeyDown(KeyCode.E) && objectToGrab != null && !isHolding)
        {
            GrabObject();
        }
        // Si el jugador presiona el botón de lanzar (ejemplo, tecla 'Q') y está sosteniendo un objeto
        else if (Input.GetKeyDown(KeyCode.Q) && isHolding)
        {
            ThrowObject();
        }

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




    void GrabObject()
    {
        isHolding = true;
        objectToGrab.transform.SetParent(grabPoint); // Hacer el objeto hijo del punto de agarre
        objectToGrab.transform.position = grabPoint.position; // Alinear la posición
        objectToGrab.GetComponent<Rigidbody2D>().isKinematic = true; // Desactivar físicas mientras se agarra
    }

    void ThrowObject()
    {
        isHolding = false;
        objectToGrab.transform.SetParent(null); // Soltar el objeto
        Rigidbody2D rb = objectToGrab.GetComponent<Rigidbody2D>();
        rb.isKinematic = false; // Volver a activar las físicas
        rb.gravityScale = 1;

        // Aplicar la fuerza para lanzar el objeto
        rb.AddForce(transform.right * throwForce, ForceMode2D.Impulse);

        // Limitar la velocidad máxima después de lanzar
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10f); // Limita la velocidad a 10 unidades
        objectToGrab = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grabbable"))
        {
            objectToGrab = collision.gameObject; // Guardar el objeto para agarrar
        }
    }

    // Detectar cuando el jugador se aleja del objeto
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grabbable"))
        {
            objectToGrab = null; // Ya no puede agarrar el objeto
        }
    }
}






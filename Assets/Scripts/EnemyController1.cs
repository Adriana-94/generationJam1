using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    public float speedEnemy = 5.0f;  // Velocidad del enemigo
    private Rigidbody2D rbEnemy;
    private Transform player;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Usamos FixedUpdate para que el movimiento esté sincronizado con la física
    void FixedUpdate()
    {
        // Direccion hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;

        // Aplicar velocidad solo en el eje X y mantener la velocidad en Y
        rbEnemy.velocity = new Vector2(direction.x * speedEnemy, rbEnemy.velocity.y);
    }
}


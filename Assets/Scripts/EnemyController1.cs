using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    // Start is called before the first frame update
    float speedEnemy = 5.0f;
    Rigidbody2D rbEnemy;
    Transform player;
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Convertir la posición del jugador a Vector2
        Vector2 playerPosition = new Vector2(player.position.x, rbEnemy.position.y); // Mantener la posición Y del enemigo

        // Calcular la dirección solo en el eje X
        Vector2 lookDirection = new Vector2(playerPosition.x - rbEnemy.position.x, 0).normalized;

        // Aplicar la fuerza solo en el eje X
        rbEnemy.AddForce(lookDirection * speedEnemy);
    }
}

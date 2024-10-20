using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentPoint;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = PointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint = PointB.transform)
        {
            rb.velocity = new Vector2(speed,0);
        }
        else 
        { 
            rb.velocity = new Vector2 (-speed,0);
        }
    }
}

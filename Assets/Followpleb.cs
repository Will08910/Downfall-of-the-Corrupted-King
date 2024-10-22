using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Followpleb : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    public bool playerInRadius;

    private Transform currentPoint;

    public Animator anim;

    SpriteRenderer sr;

    LayerMask groundLayerMask;

    public GameObject player;

    public bool flip;

    Rigidbody2D rb;

    public float speed;

    private float move;

    public float maxSpeed = 6;

    CircleCollider2D CCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        CCol = GetComponent<CircleCollider2D>();
        currentPoint = pointB.transform;
        playerInRadius = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRadius = true;
            if (playerInRadius == true)
            {
                Vector2 scale = transform.localScale;
                if (player.transform.position.x > transform.position.x)
                {
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                    sr.flipX = false;
                }

                else
                {
                    transform.Translate(speed * Time.deltaTime * -1, 0, 0);
                    sr.flipX = true;
                }

                transform.localScale = scale;
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            }
        
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        playerInRadius = false;
    }
    public void Patrol()
    {
        if (playerInRadius == false)
        {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
                sr.flipX = true;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                sr.flipX = false;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomFollowpleb : MonoBehaviour
{
    public GameObject player;

    public float speed;

    SpriteRenderer sr;

    public float maxSpeed = 6;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

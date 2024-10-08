using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    public Animator anim;
    private float Move;
    public int speed = 10;
    public bool isFacingRight;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoRayCollisionCheck();
        MoveSprite();
    }

    void MoveSprite()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, 11, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey("left") == true)
        {
            rb.velocity = new Vector2(speed * -1f, rb.velocity.y);
            sr.flipX = true;
        }

        if (Input.GetKey("right") == true)
        {
            rb.velocity = new Vector2(speed * 1f, rb.velocity.y);
            sr.flipX = false;
        }

        if (Move >= 0.1f || Move <= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void DoRayCollisionCheck()
    {
        float rayLength = 0.35f;

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;
        isGrounded = false;

        if (hit.collider != null)
        {
            hitColor = Color.green;
            isGrounded = true;
        }
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);

    }
}

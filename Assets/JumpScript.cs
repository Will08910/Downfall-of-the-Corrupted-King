using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class JumpScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    LayerMask playerLayerMask;

    public Animator anim;

    public GameObject player;

    public bool flip;

    Rigidbody2D rb;

    public float speed;

    private float Move;

    private bool isGrounded;

    public float maxSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        playerLayerMask = LayerMask.GetMask("Player");
        isGrounded = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
            {
            DoRayCollisionCheck();

            Vector2 scale = transform.localScale;

            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            }

            transform.localScale = scale;

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }


    void DoRayCollisionCheck()
    {
        float rayLength = 0.03f;

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask | playerLayerMask);

        anim.SetBool("isGrounded", false);
        Color hitColor = Color.white;
        isGrounded = false;

        if (hit.collider != null)
        {
            anim.SetBool("isGrounded", true);
            hitColor = Color.green;
            rb.AddForce(new Vector3(0, 30, 0), ForceMode2D.Impulse);
        }
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(2);
        isGrounded = true;
        print("num");
    }
}

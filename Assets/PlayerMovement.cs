using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    public LayerMask enemyLayers;
    public Animator anim;
    public float Move = 10;
    public int speed = 10;
    public bool isFacingRight;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool isGrounded;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KBActive;

    public bool KnockFromRight;

    public GameObject Sword;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        enemyLayers = LayerMask.GetMask("Enemies");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("isSword", false);
    }

    // Update is called once per frame
    void Update()
    {
        DoRayCollisionCheck();
        MoveSprite();
        if (Sword != null )
        {
            if (Sword.activeInHierarchy)
            {
                anim.SetBool("isSword", false);
            }
            else
            {
                anim.SetBool("isSword", true);
            }
        }
        else
        {
            Debug.LogWarning("GameObject is not assigned!");
        }

    }

    void MoveSprite()
    {
        Move = Input.GetAxisRaw("Horizontal");

        if(KBCounter <= 0)
        {
            rb.velocity = new Vector2(Move * speed, rb.velocity.y);
        }

        else
        {
            if(KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, rb.velocity.y);
                speed = 0;
                StartCoroutine(KBDelay());
            }

            if(KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, rb.velocity.y);
                speed = 0;
                StartCoroutine(KBDelay());
            }

            KBCounter -= Time.deltaTime;
        }

        if (anim.GetBool("isSword") && Input.GetKeyDown(KeyCode.F) == true)
        {
            anim.SetTrigger("Attack");

            Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(1);
            }
        }

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, 11, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey("left") == true && speed == 7)
        {
            rb.velocity = new Vector2(speed * -1f, rb.velocity.y);
            sr.flipX = true;
        }

        if (Input.GetKey("right") == true && speed == 7)
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
        float rayLength = 0.5f;

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

    IEnumerator KBDelay()
    {
        yield return new WaitForSeconds(.5f);
        speed = 7;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

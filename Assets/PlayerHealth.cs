using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public SpriteRenderer sprite;

    void Start()
    {
        health = maxHealth;
    }

public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(FlashRed());
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }
}

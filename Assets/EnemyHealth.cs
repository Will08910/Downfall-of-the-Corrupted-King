using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] itemDrops;

    public GameObject Sword;

    public int maxHealth = 1;

    int currentHealth;

    public GameObject Enemy;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(AnimDelay());
    }

    IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(.5f);
        Sword.SetActive(true);
        Enemy.SetActive(false);
        itemDrop();
    }

    private void itemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
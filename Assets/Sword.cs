using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject sword;
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(true);
        light.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sword.SetActive(false);
            light.SetActive(false);
        }
    }
}

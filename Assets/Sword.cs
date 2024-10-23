using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Sword1;
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        Sword1.SetActive(true);
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
            Sword1.SetActive(false);
            light.SetActive(false);
        }
    }
}

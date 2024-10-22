using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject light;
    public GameObject light2;
    public GameObject secretDoor2;
    private bool isPlayerInside = false;

    // Start is called before the first frame update

    void Start()
    {
        light2.SetActive(false);
        
    }
    void Update()
    {
        // Check if the player is inside and "E" is pressed
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject); // Destroy this GameObject
            light2.SetActive(true);
            secretDoor2.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player (or specific object) enters the trigger
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

}

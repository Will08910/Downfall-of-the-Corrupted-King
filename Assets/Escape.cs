using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public IsPickedUp IsPickedUp;
    public bool isPlayerInside;
    public GameObject winText;

    void Start()
    {
        isPlayerInside = false;

        if (winText != null)
        {
            winText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("WinText is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        EscapeDoor();
    }

    public void EscapeDoor()
    {
        if (IsPickedUp != null && IsPickedUp.doorOpen && isPlayerInside)
        {
            Debug.Log("works");
            winText.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false; // Optionally reset when the player leaves
        }
    }
}
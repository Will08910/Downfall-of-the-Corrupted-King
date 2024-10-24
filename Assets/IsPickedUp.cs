using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPickedUp : MonoBehaviour
{
    public bool doorOpen;

    private void Start()
    {
        doorOpen = false;
    }

    public void PickUp()
    {
        doorOpen = true;
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

}

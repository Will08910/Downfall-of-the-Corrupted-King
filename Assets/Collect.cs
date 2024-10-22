using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject light;
    public GameObject light2;
    public GameObject secretDoor2;

    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(true);
        secretDoor2.SetActive(true);
        light2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            print("works");
            light.SetActive(false);
            secretDoor2.SetActive(false);
            light2.SetActive(true);
        }
    }

}

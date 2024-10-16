using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagReduction : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillSwitch();
    }

    void KillSwitch()
    {
        if (player.transform.position.y < -4)
        {
            Destroy(gameObject);
        }
    }
}

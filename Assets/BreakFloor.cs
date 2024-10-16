using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakFloor : MonoBehaviour
{

    public ParticleSystem collisionParticleSystem;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && once)
        {
            StartCoroutine(HolOn());
        }

    }

    IEnumerator HolOn()
    {
        yield return new WaitForSeconds(1.1f);
        var em = collisionParticleSystem.emission;
        var dur = collisionParticleSystem.duration;

        em.enabled = true;
        collisionParticleSystem.Play();

        once = false;
        Invoke(nameof(DestroyObj), dur);
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SecretDoorOpener : MonoBehaviour
{

    public GameObject SecretDoor;
    public GameObject Light;
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;
    public GameObject Torch;

    // Start is called before the first frame update
    void Start()
    {
        Torch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && once)
        {
            SecretDoor.SetActive(false);
            Light.SetActive(false);
            Torch.SetActive(true);

            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);
        }
        
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

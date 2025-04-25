using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public AudioClip mindySound;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource && mindySound)
            {
                AudioSource.PlayClipAtPoint(mindySound, transform.position, 10f);
            }
            ResourceCounter.instance.AddResource(1);
            Destroy(gameObject);
        }
    }
}

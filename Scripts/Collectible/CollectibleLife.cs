using System;
using UnityEngine;

public class CollectibleLife : MonoBehaviour
{

    public AudioClip mindySound;
    public AudioSource audioSource;
    public int value = 20;

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
            other.GetComponent<PlayerCombat>().CollectLife(value);
            Destroy(gameObject);
        }
    }
}

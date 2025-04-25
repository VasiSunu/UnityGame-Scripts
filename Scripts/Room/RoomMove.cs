using System;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraFollow cam;
    private bool playerInTrigger = false;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !playerInTrigger)
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            playerInTrigger = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
} 

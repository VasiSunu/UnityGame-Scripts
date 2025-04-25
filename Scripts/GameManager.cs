using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int globalDifficulty = 0;
    public int clearedRoomCount = 0;
    public event Action<RoomController> OnRoomCleared;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RoomCleared(RoomController room)
    {
        clearedRoomCount++;
        globalDifficulty += 5;
        OnRoomCleared?.Invoke(room);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject normalEnemyPrefab;
    public GameObject strongerEnemyPrefab;
    public bool ignoreGlobalDifficulty = false;

    private int enterCount = 0;
    private int localClearedWaves = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool playerInside = false;

    void OnEnable()
    {
        GameManager.Instance.OnRoomCleared += OnOtherRoomCleared;
    }

    void OnDisable()
    {
        GameManager.Instance.OnRoomCleared -= OnOtherRoomCleared;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = true;
        enterCount++;

        foreach (var enemy in activeEnemies)
        {
            if (enemy != null)
            {
                var ai = enemy.GetComponent<EnemyFollow>();
                if (ai != null)
                    ai.SetActive(true);
            }
        }
        
        SpawnBasedOnProgress();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
        
        foreach (var enemy in activeEnemies)
        {
            if (enemy != null)
            {
                var ai = enemy.GetComponent<EnemyFollow>();
                if (ai != null)
                    ai.SetActive(false);
            }
        }

        // Verificăm dacă TOȚI inamicii au fost distruși
        activeEnemies.RemoveAll(e => e == null);
        if (activeEnemies.Count == 0)
        {
            GameManager.Instance.RoomCleared(this);
            localClearedWaves = 0; // Se resetează pentru următoarea intrare
        }
    }

    private void SpawnBasedOnProgress()
    {
        int difficulty = ignoreGlobalDifficulty ? 0 : GameManager.Instance.globalDifficulty;

        int wavePower = localClearedWaves + difficulty / 10;

        int enemyCount = Mathf.Clamp(2 + wavePower, 2, 6);
        GameObject prefabToUse = wavePower < 4 ? normalEnemyPrefab : strongerEnemyPrefab;

        for (int i = 0; i < enemyCount && i < enemySpawnPoints.Length; i++)
        {
            GameObject enemy = Instantiate(prefabToUse, enemySpawnPoints[i].position, Quaternion.identity);
            activeEnemies.Add(enemy);
            enemy.GetComponent<EnemyFollow>()?.SetActive(true);
        }
    }

    private void OnOtherRoomCleared(RoomController clearedRoom)
    {
        if (clearedRoom != this)
        {
            localClearedWaves++;
        }
    }
}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(enemyPrefab, point.position, point.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

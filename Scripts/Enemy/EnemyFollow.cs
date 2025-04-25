using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    private bool isActive = true;
    private float attackRange;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        attackRange = GetComponent<EnemyCombat>().attackRange;
    }

    void Update()
    {
        if (!isActive || player == null) return;
        if (Vector3.Distance(player.position, transform.position) > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        
    }
    
    public void SetActive(bool value)
    {
        isActive = value;
    }
}

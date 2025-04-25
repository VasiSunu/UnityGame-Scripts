using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    [SerializeField] private HealthBarPlayer healthBar;
    

    public float attackOffset = 1f;
    public PlayerMovement1 movementScript;
    private PlayerStats stats;
    void Awake()
    {
        stats = PlayerStats.Instance;
    }
    void Start()
    {
        healthBar.updateHealthBar(stats.currentHealth, stats.maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        Vector2 dir = movementScript.lastMoveDir;

        if (dir != Vector2.zero)
        {
            attackPoint.localPosition = dir * attackOffset;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, stats.attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 knockbackDir = (enemy.transform.position - transform.position);
            enemy.GetComponent<EnemyCombat>().TakeDamage(stats.attackDamage, stats.knockbackForce, knockbackDir);
        }
        
    }

    public void TakeDamage(int damage)
    {
        stats.currentHealth -= damage;
        healthBar.updateHealthBar(stats.currentHealth, stats.maxHealth);
        Debug.Log("Player took " + damage + " damage. Current HP: " + stats.currentHealth);

        if (stats.currentHealth <= 0)
        {
            Debug.Log("Player DIED.");
            // Adaugă logică de game over
        }
    }
    
    public void CollectLife(int value)
    {
        stats.AddHealth(value);
        healthBar.updateHealthBar(stats.currentHealth, stats.maxHealth);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, stats.attackRange);
    }
}
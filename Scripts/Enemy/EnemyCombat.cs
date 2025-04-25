using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    public int attackDamage = 10;
    public float attackRange = 1.0f;
    public float attackCooldown = 1.5f;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public Rigidbody2D rb;

    public Animator _animator;
    
    public GameObject healthPickupPrefab;
    public GameObject resourcePickupPrefab;

    [SerializeField] private FloatinHealthBar healthBar;

    private float lastAttackTime = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<FloatinHealthBar>();
        healthBar.updateHealthBar(maxHealth,maxHealth);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            _animator.SetTrigger("Attack");
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(int damage, float knockbackForce, Vector2 knockbackDirection)
    {
        currentHealth -= damage;
        rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        healthBar.updateHealthBar(currentHealth,maxHealth);
        Debug.Log(name + " took " + damage + " damage. Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropLoot();
        Debug.Log(name + " DIED.");
        Destroy(gameObject);
        
    }
    
    private void DropLoot()
    {
        int chance = Random.Range(0,101);
        Debug.Log(chance);
        if (chance < 10){}
        else if (chance < 50)
        {
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(resourcePickupPrefab, transform.position, Quaternion.identity);
        }
    }
    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
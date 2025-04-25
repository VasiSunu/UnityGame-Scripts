using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int maxHealth = 100;
    public int currentHealth;
    public int attackDamage = 20;
    public float attackRange = 1.5f;
    public float knockbackForce = 5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        currentHealth = maxHealth;
    }

    public void AddHealth(int healthAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healthAmount, maxHealth);
    }

    public void UpgradeHealth(int extra)
    {
        maxHealth += extra;
        currentHealth = maxHealth;
    }

    public void UpgradeAttack(int extraDamage)
    {
        attackDamage += extraDamage;
    }

    public void UpgradeRange(float extraRange)
    {
        attackRange += extraRange;
    }
}
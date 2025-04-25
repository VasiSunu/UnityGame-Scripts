using UnityEngine;

public class HealthRegenItem : ShopItem
{
    public int healthAmount = 10;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        playerStats.AddHealth(healthAmount);
    }
}

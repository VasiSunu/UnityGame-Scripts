using UnityEngine;

public abstract class ShopItem : MonoBehaviour
{
    public int price;
    public string description;
    public ShopItem nextLevelItemPrefab;

    public abstract void ApplyEffect(PlayerStats playerStats);

    public virtual bool CanBuy(int playerResources) => playerResources >= price;
}
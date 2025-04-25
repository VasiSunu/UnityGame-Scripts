using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public ShopItem currentItem;
    public Transform itemDisplayAnchor;
    public TMP_Text priceText;
    public TMP_Text globalDescriptionText;

    private GameObject currentItemGO;
    private PlayerStats player;
    private ResourceCounter resources;
    private Transform playerTransform;

    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
            playerTransform = playerGO.transform;
        player = FindObjectOfType<PlayerStats>();
        resources = FindObjectOfType<ResourceCounter>();
        LoadItem(currentItem);
    }

    void LoadItem(ShopItem item)
    {
        if (currentItemGO != null) Destroy(currentItemGO);

        currentItem = item;
        currentItemGO = Instantiate(item.gameObject, itemDisplayAnchor);
        priceText.text = item.price.ToString();
    }

    void Update()
    {

        if (Vector3.Distance(playerTransform.transform.position, transform.position) < 0.5f)
        {
            if (globalDescriptionText != null)
            {
                globalDescriptionText.text = currentItem.description;
            }
                
            if (Input.GetKeyDown(KeyCode.E) && resources.Buy(currentItem.price))
            {
                currentItem.ApplyEffect(player);
                if (currentItem.nextLevelItemPrefab != null)
                {
                    LoadItem(currentItem.nextLevelItemPrefab);
                }
                else
                {
                    ShopItem upgraded = Instantiate(currentItem.gameObject, itemDisplayAnchor).GetComponent<ShopItem>();
                    
                    upgraded.price += 1;

                    // if (upgraded is MaxHealthItem mh)
                    //     mh.extraMaxHealth += 10;
                    // else if (upgraded is AttackPowerItem ap)
                    //     ap.bonusDamage += 3;
                    // else if (upgraded is HealthRegenItem hr)
                    //     hr.healthAmount += 5;

                    LoadItem(upgraded);
                }
            }
        }
        else
        {
            if (globalDescriptionText != null && globalDescriptionText.text == currentItem.description)
                globalDescriptionText.text = "";
        }
    }
}
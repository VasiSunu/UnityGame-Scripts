using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{

    public static ResourceCounter instance;
    public int resourceCount = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddResource(int amount)
    {
        resourceCount += amount;
        UpdateUI();
    }

    public bool CanBuy(int amount)
    {
        return amount <= resourceCount;
    }

    public bool Buy(int amount)
    {
        if (CanBuy(amount))
        {
            resourceCount -= amount;
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        scoreText.text = "Resurse: " + resourceCount;
    }
}

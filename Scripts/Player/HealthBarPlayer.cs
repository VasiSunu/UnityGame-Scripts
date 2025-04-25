using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    
    public void updateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}

using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FloatinHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        camera = Camera.main;
    }

    public void updateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    private void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
}

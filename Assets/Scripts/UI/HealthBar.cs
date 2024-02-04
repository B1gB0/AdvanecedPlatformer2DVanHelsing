using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthBar : Bar
{
    private Health _health;

    private void OnEnable()
    {
        MaxValue = _health.StartHealth;
        _health.HealthChanged += OnCgangedValue;
        Slider.value = MaxValue / MaxValue;
        Text.text = ((int)MaxValue).ToString() + "/" + ((int)MaxValue).ToString();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnCgangedValue;
    }

    public void GetHealth(Health health)
    {
        _health = health;
    }
}

using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        MaxValue = _player.Health;
        _player.HealthChanged += OnCgangedValue;
        Slider.value = MaxValue / MaxValue;
        Text.text = ((int)MaxValue).ToString() + "/" + ((int)MaxValue).ToString();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnCgangedValue;
    }
}

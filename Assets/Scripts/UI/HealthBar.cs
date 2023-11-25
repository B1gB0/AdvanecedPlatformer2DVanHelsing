using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private Coroutine _coroutine;
    private float _recoveryRate = 10f;

    public event UnityAction<float, float, float> HealthChanged;

    private void OnEnable()
    {
        MaxValue = _player.Health;
        HealthChanged += OnCgangedValue;
        Slider.value = MaxValue / MaxValue;
        Text.text = ((int)MaxValue).ToString() + "/" + ((int)MaxValue).ToString();
    }

    private void OnDisable()
    {
        HealthChanged -= OnCgangedValue;
    }

    public void OnChangeHealth(float currentHealth, float targetHealth, float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealth(currentHealth, targetHealth, health));
    }

    private IEnumerator ChangeHealth(float currentHealth, float targetHealth, float health)
    {
        while (currentHealth != targetHealth)
        {
            currentHealth = Mathf.MoveTowards
            (currentHealth, targetHealth, _recoveryRate * Time.deltaTime);
            HealthChanged?.Invoke(currentHealth, health, targetHealth);

            yield return null;
        }
    }
}

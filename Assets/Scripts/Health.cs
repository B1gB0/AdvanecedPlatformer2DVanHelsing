using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    protected float TargetHealth;
    protected float CurrentHealth;

    private Coroutine _coroutine;
    private float _recoveryRate = 10f;

    public float StartHealth => _health;

    public event UnityAction<float, float, float> HealthChanged;

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

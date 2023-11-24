using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _health;

    private PlayerMovement _playerMovement;
    private Weapon _currentWeapon;
    private Coroutine _coroutine;
    private float _currentHealth;
    private float _targetHealth;
    private float _recoveryRate = 10f;

    public event UnityAction<float, float, float> HealthChanged;

    public float Money { get; private set; }
    public float Health => _health;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.Velocity.x == 0)
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(float damage)
    {
       _targetHealth = _currentHealth - damage;
        OnChangeHealth();

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(float health)
    {
        _targetHealth = _currentHealth + health;
        
        if (_targetHealth > _health)
        {
            _targetHealth = _health;
        }
        else
        {
            OnChangeHealth();
        }
    }

    public void AddMoney(float money)
    {
        Money += money;
    }

    private void OnChangeHealth()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while (_currentHealth != _targetHealth)
        {
            _currentHealth = Mathf.MoveTowards
            (_currentHealth,_targetHealth, _recoveryRate * Time.deltaTime);
            HealthChanged?.Invoke(_currentHealth, _health, _targetHealth);

            yield return null;
        }
    }
}

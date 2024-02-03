using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Health
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _healthBarPoint;

    private PlayerMovement _playerMovement;
    private Weapon _currentWeapon;

    public float Money { get; private set; }

    private void Awake()
    {
        _healthBar.GetHealth(this);
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        _currentWeapon = _weapons[0];
        _currentHealth = StartHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.Velocity.x == 0)
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    private void LateUpdate()
    {
        _healthBar.transform.position = _healthBarPoint.transform.position;
    }

    public void ApplyDamage(float damage)
    {
       _targetHealth = _currentHealth - damage;
       _healthBar.OnChangeHealth(_currentHealth, _targetHealth, StartHealth);
       _currentHealth = _targetHealth;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(float health)
    {
        _targetHealth = _currentHealth + health;
        
        if (_targetHealth > StartHealth)
        {
            _targetHealth = StartHealth;
            _currentHealth = _targetHealth;
        }
        else
        {
            _healthBar.OnChangeHealth(_currentHealth, _targetHealth, StartHealth);
            _currentHealth = _targetHealth;
        }
    }

    public void AddMoney(float money)
    {
        Money += money;
    }
}

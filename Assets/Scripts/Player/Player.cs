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
    private float _currentHealth;

    public event UnityAction<float, float> HealthChanged;

    public float Money { get; private set; }

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
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(float health)
    {
        _currentHealth += health;

        if (_currentHealth > _health)
            _currentHealth = _health;
    }

    public void AddMoney(float money)
    {
        Money += money;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Health
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private List<Abillity> _abillities;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Collider2D _rangeAbility;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _healthBarPoint;

    private List<Enemy> _enemies = new List<Enemy>();
    private PlayerMovement _playerMovement;
    private Abillity _currentAbillity;
    private Weapon _currentWeapon;
    private Coroutine _coroutine;

    private int _counterTimeAbillity;
    private int _durationAbillity;

    public float Money { get; private set; }

    private void Awake()
    {
        _healthBar.GetHealth(this);
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        _currentWeapon = _weapons[0];

        _currentAbillity = _abillities[0];
        _durationAbillity = _currentAbillity.AbillityAction.Duration;

        CurrentHealth = StartHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.Velocity.x == 0)
        {
            _currentWeapon.Shoot(_shootPoint);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(UseAbillity());
        }
    }

    private void LateUpdate()
    {
        _healthBar.transform.position = _healthBarPoint.transform.position;
    }

    public void ApplyDamage(float damage)
    {
       TargetHealth = CurrentHealth - damage;
       this.OnChangeHealth(CurrentHealth, TargetHealth, StartHealth);
       CurrentHealth = TargetHealth;

        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddHealth(float health)
    {
        TargetHealth = CurrentHealth + health;
        
        if (TargetHealth > StartHealth)
        {
            TargetHealth = StartHealth;
            CurrentHealth = TargetHealth;
        }
        else
        {
            this.OnChangeHealth(CurrentHealth, TargetHealth, StartHealth);
            CurrentHealth = TargetHealth;
        }
    }

    public void AddMoney(float money)
    {
        Money += money;
    }

    private IEnumerator UseAbillity()
    {
        float wait = 1f;
        WaitForSeconds waitForSeconds = new WaitForSeconds(wait);

        for (_counterTimeAbillity = 0; _counterTimeAbillity != _durationAbillity + 1; _counterTimeAbillity++)
        {
            _currentAbillity.ApplyAction(_enemies, this);

            yield return waitForSeconds;
        }
    }
}

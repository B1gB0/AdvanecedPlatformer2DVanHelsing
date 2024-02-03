using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    protected float _targetHealth;
    protected float _currentHealth;

    public float StartHealth => _health;
}

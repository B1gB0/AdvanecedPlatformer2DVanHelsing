using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] protected int _capacity;

    private List<Enemy> _pool = new();

    protected void Initialize(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out Enemy result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
using UnityEngine;

public class GenericFactoy<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    [SerializeField] protected Transform[] _spawnPoint;

    private int _numberSpawnPoint;

    private void Start()
    {
        while (_numberSpawnPoint < _spawnPoint.Length)
        {
            GetNewInstance();
        }
    }

    private T GetNewInstance()
    {
        Vector3 position = _spawnPoint[_numberSpawnPoint].transform.position;
        _numberSpawnPoint++;

        return Instantiate(_prefab, position, Quaternion.identity);
    }
}

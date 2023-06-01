using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected Transform _container;
    [SerializeField] protected int _capacity;

    private GameObject[] _pool;

    public GameObject[] Pool => _pool;

    public bool TryGetObject(out GameObject result)
    {
        result = null;
        foreach (GameObject obj in _pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                result = obj;
                break;
            }
        }

        return result != null;
    }

    protected void Initialize(IObjectFromPool prefab)
    {
        _pool = new GameObject[_capacity];
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab.GameObject, _container);
            spawnedObject.gameObject.SetActive(false);
            _pool[i] = spawnedObject;
        }
    }
}
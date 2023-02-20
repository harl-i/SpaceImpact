using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject _container;
    [SerializeField] protected int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public List<GameObject> Pool => _pool;

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }

    protected void Initialize(IObjectFromPool prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab.GetGameObject(), _container.transform);
            spawnedObject.transform.SetParent(_container.transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }
}
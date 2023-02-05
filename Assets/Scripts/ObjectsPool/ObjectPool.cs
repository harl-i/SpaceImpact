using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject _container;
    [SerializeField] protected int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, _container.transform);
            spawnedObject.transform.SetParent(_container.transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }
}

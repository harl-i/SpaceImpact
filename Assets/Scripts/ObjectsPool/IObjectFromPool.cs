using UnityEngine;

public interface IObjectFromPool
{
    public void ReturnToPool();

    public GameObject GetGameObject();
}

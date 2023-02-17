using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBonus : MonoBehaviour, IObjectFromPool
{
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}

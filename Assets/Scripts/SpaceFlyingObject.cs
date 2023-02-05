using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFlyingObject : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected BulletsPool _bulletsPool;

    protected void Shoot()
    {
        GameObject bullet;
        _bulletsPool.TryGetObject(out bullet);

        if (bullet != null)
        {
            bullet.transform.position = _shootPoint.transform.position;
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("bullets pool is empty");
        }
    }
}

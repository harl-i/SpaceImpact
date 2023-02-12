using UnityEngine;

public abstract class SpaceFlyingObject : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected BulletsPool _bulletsPool;
    [SerializeField] protected float _shootDelay;

    protected float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

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

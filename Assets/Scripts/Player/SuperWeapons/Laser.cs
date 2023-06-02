using UnityEngine;

public class Laser : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private int _damage = 15;
    [SerializeField] private float _lifeTime = 0.7f;

    private float _elapsedTime;
    private Vector3 _offsetX = new Vector3(5.75f, 0, 0);
    private Vector3 _rectangle = new Vector3(10.2f, 0.2f, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position + _offsetX, _rectangle, 0);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }

    private void OnEnable()
    {
        _elapsedTime = 0;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;


        if (_elapsedTime > _lifeTime)
        {
            ReturnToPool();
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + _offsetX, _rectangle);
    }
}

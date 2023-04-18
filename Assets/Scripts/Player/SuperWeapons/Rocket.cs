using UnityEngine;

public class Rocket : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _targetLayer;

    private Vector3[] _targetDirections;

    public float angleStep;
    public float radius;
    public int numOfDirections;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ShootingEnemy shootingEnemy))
        {
            shootingEnemy.ApplyDamage(_damage);
            ReturnToPool();
        }

        if (collision.TryGetComponent(out NonShootingEnemy nonShootingEnemy))
        {
            nonShootingEnemy.ApplyDamage(_damage);
            ReturnToPool();
        }
    }

    private void OnEnable()
    {
        GenerateDirections();
    }

    private void Update()
    {
        Transform target = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < _targetDirections.Length; i++)
        {
            Vector3 direction = _targetDirections[i] - transform.position;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, 100f, _targetLayer);

            if (raycastHit)
            {
                Debug.DrawRay(transform.position, direction * _raycastDistance, Color.red);

                float distance = (raycastHit.transform.position - transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    target = raycastHit.transform;
                    closestDistance = distance;
                }
            }
            else
            {
                Debug.DrawRay(transform.position, direction * _raycastDistance, Color.green);
            }
        }

        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }

    private void GenerateDirections()
    {
        _targetDirections = new Vector3[numOfDirections];

        for (int i = 0; i < numOfDirections; i++)
        {
            float angle = i * angleStep;
            float rad = angle * Mathf.Deg2Rad;

            float x = radius * Mathf.Cos(rad);
            float y = radius * Mathf.Sin(rad);

            _targetDirections[i] = new Vector3(x, y, 0);
        }
    }
}
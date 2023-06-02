using UnityEngine;

public class Rocket : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _angleStep;
    [SerializeField] private float _radius;
    [SerializeField] private int _numOfDirections;
    [SerializeField] private RocketSender _rocketSender;

    private Vector3[] _targetDirections;
    private float _playerDetectionRadiusSlope = 50f;
    private float _bossDetectionRadiusSlope = -100f;

    public RocketSender SenderType => _rocketSender;

    private void OnEnable()
    {
        GenerateDirections();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_targetLayer.value & 1 << collision.gameObject.layer) != 0)
        {
            if (collision.TryGetComponent(out IDamageable target))
            {
                target.ApplyDamage(_damage);
                ReturnToPool();
            }
        }

        if (collision.TryGetComponent(out PlayerBullet playerBullet) && _rocketSender != RocketSender.Player)
        {
            ReturnToPool();
        }
    }

    private void Update()
    {
        Homing();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void Homing()
    {
        Transform target = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < _targetDirections.Length; i++)
        {
            Vector3 direction = _targetDirections[i] - transform.position;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, _raycastDistance, _targetLayer);

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
            transform.Translate(GetDirection() * _speed * Time.deltaTime);
        }
    }

    private void GenerateDirections()
    {
        _targetDirections = new Vector3[_numOfDirections];

        for (int i = 0; i < _numOfDirections; i++)
        {
            float angle = i * _angleStep - GetDetectionRadiusSlope();
            float rad = angle * Mathf.Deg2Rad;

            float x = _radius * Mathf.Cos(rad);
            float y = _radius * Mathf.Sin(rad);

            _targetDirections[i] = new Vector3(x, y, 0);
        }
    }

    private float GetDetectionRadiusSlope()
    {
        switch (_rocketSender)
        {
            case RocketSender.Player:
                return _playerDetectionRadiusSlope;
            case RocketSender.Boss:
                return _bossDetectionRadiusSlope;
            default:
                return 0;
        }
    }

    private Vector2 GetDirection()
    {
        switch (_rocketSender)
        {
            case RocketSender.Player:
                return Vector2.right;
            case RocketSender.Boss:
                return Vector2.left;
            default:
                return Vector2.zero;
        }
    }
}

public enum RocketSender
{
    Player,
    Boss
}
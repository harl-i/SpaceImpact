using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private int _health = 3;
    private int _rockets;
    private PlayerInput _input;
    private float _elapsedTime;

    public event UnityAction<int> HealthChanged;

    public void PickedRocketBonus(int count)
    {
        _rockets += count;
    }

    public void ApplyDamage()
    {
        _health--;
        HealthChanged?.Invoke(_health);
        Debug.Log(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("GAME OVER!");
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void OnEnable()
    {
        _input.keyFirePressed += OnShoot;
    }

    private void OnDisable()
    {
        _input.keyFirePressed -= OnShoot;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    private void OnShoot()
    {
        if (_elapsedTime > _shootDelay)
        {
            Shoot();
            _elapsedTime = 0f;
        }
    }

    private void Shoot()
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

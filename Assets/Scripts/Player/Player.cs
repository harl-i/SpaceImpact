using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SuperWeaponSwitcher))]
[RequireComponent(typeof(LevelEventsListener))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(LevelEndBehaviour))]
public class Player : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private SuperWeaponSwitcher _superWeaponSwitcher;
    private PlayerInput _input;
    private PlayerMover _playerMover;
    private LevelEndBehaviour _levelEndBehavoiur;
    private int _health = 3;
    private int _rocketsCount;
    private int _lasersCount;
    private int _laserWallsCount;
    private float _shootElapsedTime;

    public Transform ShootPoint => _shootPoint;
    public int RocketsCount => _rocketsCount;
    public int LasersCount => _lasersCount;
    public int LaserWallsCount => _laserWallsCount;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> SuperShoot;

    public void PickedRocketBonus(int count)
    {
        _rocketsCount = count;
        SetSuperWeapon(SuperWeaponVariant.Rocket);
    }

    public void PickedLaserBonus(int count)
    {
        _lasersCount = count;
        SetSuperWeapon(SuperWeaponVariant.Laser);
    }

    public void PickedLaserWallBonus(int count)
    {
        _laserWallsCount = count;
        SetSuperWeapon(SuperWeaponVariant.LaserWall);
    }

    public void ReduceRocket()
    {
        if (_rocketsCount > 0)
        {
            _rocketsCount--;
            SuperShoot(_rocketsCount);
        }
    }

    public void ReduceLaser()
    {
        if (_lasersCount > 0)
        {
            _lasersCount--;
            SuperShoot(_lasersCount);
        }
    }

    public void ReduceLaserWall()
    {
        if (_laserWallsCount > 0)
        {
            _laserWallsCount--;
            SuperShoot(_laserWallsCount);
        }

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
        _superWeaponSwitcher = GetComponent<SuperWeaponSwitcher>();
        _playerMover = GetComponent<PlayerMover>();
        _levelEndBehavoiur = GetComponent<LevelEndBehaviour>();
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _playerMover.enabled = true;
        _levelEndBehavoiur.enabled = false;
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
        _shootElapsedTime += Time.deltaTime;
    }

    private void OnShoot()
    {
        if (_shootElapsedTime > _shootDelay)
        {
            Shoot();
            _shootElapsedTime = 0f;
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

    private void SetSuperWeapon(SuperWeaponVariant variant)
    {
        switch (variant)
        {
            case SuperWeaponVariant.Rocket:
                _superWeaponSwitcher.ActivateRocketGun();
                break;
            case SuperWeaponVariant.Laser:
                _superWeaponSwitcher.ActivateLaserGun();
                break;
            case SuperWeaponVariant.LaserWall:
                _superWeaponSwitcher.ActivateLaserWallGun();
                break;
            default:
                break;
        }
    }
}
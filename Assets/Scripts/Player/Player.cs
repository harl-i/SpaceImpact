using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SuperWeaponSwitcher))]
[RequireComponent(typeof(LevelEventsListener))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(LevelEndBehaviour))]
[RequireComponent(typeof(LevelTransition))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private GameObject _shield;
    [SerializeField] private AudioSource _shootSound;

    private SuperWeaponSwitcher _superWeaponSwitcher;
    private PlayerInput _input;
    private PlayerMover _playerMover;
    private LevelEndBehaviour _levelEndBehavoiur;
    private LevelTransition _levelTransition;
    private SaveLoadSystem _saveLoadSystem;
    private int _health = 3;
    private int _rocketsCount;
    private int _lasersCount;
    private int _laserWallsCount;
    private float _shootElapsedTime;
    private bool _isShieldActivated = false;
    private int _continuum;
    private int _currentLevel;
    private int _lastShoot = 1;

    public Transform ShootPoint => _shootPoint;
    public int RocketsCount => _rocketsCount;
    public int LasersCount => _lasersCount;
    public int LaserWallsCount => _laserWallsCount;
    public int Health => _health;
    public int CurrentLevel => _currentLevel;
    public int Continuum => _continuum;

    public static event UnityAction PlayerDied;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> SuperShoot;
    public event UnityAction SuperWeaponChargeDepleted;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _superWeaponSwitcher = GetComponent<SuperWeaponSwitcher>();
        _playerMover = GetComponent<PlayerMover>();
        _levelEndBehavoiur = GetComponent<LevelEndBehaviour>();
        _levelTransition = GetComponent<LevelTransition>();
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
    }

    private void OnEnable()
    {
        _input.KeyShootPressed += OnShoot;
    }

    private void OnDisable()
    {
        _input.KeyShootPressed -= OnShoot;
    }

    private void Start()
    {
        PlayerData playerData = _saveLoadSystem.Load();

        HealthChanged?.Invoke(playerData.Health);
        _playerMover.enabled = true;
        _levelEndBehavoiur.enabled = false;
    }

    private void Update()
    {
        _shootElapsedTime += Time.deltaTime;
    }

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

    public void PickedHealthBonus(int count)
    {
        _health += count;
        HealthChanged?.Invoke(_health);
    }

    public void ReduceRocket()
    {
        if (_rocketsCount > 0)
        {
            _rocketsCount--;
            SuperShoot(_rocketsCount);
        }

        if (_rocketsCount == 0)
        {
            SuperWeaponChargeDepleted?.Invoke();
        }
    }

    public void ReduceLaser()
    {
        if (_lasersCount > 0)
        {
            _lasersCount--;
            SuperShoot(_lasersCount);
        }

        if (_lasersCount == 0)
        {
            SuperWeaponChargeDepleted?.Invoke();
        }
    }

    public void ReduceLaserWall()
    {
        if (_laserWallsCount > 0)
        {
            _laserWallsCount--;
            SuperShoot(_laserWallsCount);
        }

        if (_laserWallsCount == 0)
        {
            SuperWeaponChargeDepleted?.Invoke();
        }
    }

    public void ApplyDamage(int damage)
    {
        if (_isShieldActivated == false)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
            {
                PlayerDied?.Invoke();
                Die();
            }
            else
            {
                StartCoroutine(ActivateTemporaryShield());
            }
        }
    }

    private IEnumerator ActivateTemporaryShield()
    {
        _shield.SetActive(true);
        _isShieldActivated = true;

        yield return new WaitForSeconds(3);

        _shield.SetActive(false);
        _isShieldActivated = false;
    }

    public void Die()
    {
        if (_continuum > 0)
        {
            _levelTransition.LoadContinuumScreen();
        }
        else
        {
            _levelTransition.LoadGameOverScreen();
        }
    }

    public void SetHelath(int count)
    {
        _health = count;
    }

    public void SetRockets(int count)
    {
        _rocketsCount = count;
    }

    public void SetLasers(int count)
    {
        _lasersCount = count;
    }

    public void SetLasersWalls(int count)
    {
        _laserWallsCount = count;
    }

    public void SetContinuums(int count)
    {
        _continuum = count;
    }

    public void SetCurrentLevel(int count)
    {
        _currentLevel = count;
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
            bullet.transform.SetParent(null);
            bullet.SetActive(true);
            _shootSound.Play();
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
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]
public abstract class SuperWeapon : MonoBehaviour
{
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected AudioSource _superShootSound;

    protected PlayerInput _playerInput;
    protected Player _player;
    protected float _elapsedTime;
    private float _timeOverDelay = 5f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _player = GetComponent<Player>();
        _elapsedTime = _timeOverDelay;
    }

    private void OnEnable()
    {
        _playerInput.KeySuperShootPressed += OnSuperShoot;
    }

    private void OnDisable()
    {
        _playerInput.KeySuperShootPressed -= OnSuperShoot;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public abstract SuperWeaponVariant GetSuperWeaponType();

    protected abstract void OnSuperShoot();

    protected abstract void Shoot();
}

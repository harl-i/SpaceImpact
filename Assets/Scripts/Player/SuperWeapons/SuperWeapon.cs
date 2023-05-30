using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]
public abstract class SuperWeapon : MonoBehaviour
{
    [SerializeField] protected float _shootDelay;

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
        _playerInput.keySuperFirePressed += OnSuperShoot;
    }

    private void OnDisable()
    {
        _playerInput.keySuperFirePressed -= OnSuperShoot;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    protected abstract void OnSuperShoot();

    protected abstract void Shoot();

    public abstract SuperWeaponVariant GetSuperWeaponType();
}

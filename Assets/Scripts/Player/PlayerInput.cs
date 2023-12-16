using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private ShootButton _shootButton;
    [SerializeField] private SuperWeaponButton _superWeaponButton;
    [SerializeField] private float shootDelay = 0.1f;

    private float _nextShootTime = 0f;
    private bool _canShoot = true;

    public event UnityAction KeyShootPressed;
    public event UnityAction KeySuperShootPressed;

    private void OnEnable()
    {
        GamePause.OnPauseStateChanged += UpdateCanShoot;
    }

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        InputHandler();
    }

    private void OnDisable()
    {
        GamePause.OnPauseStateChanged -= UpdateCanShoot;
    }

    public void EnableMobileButtons(int enable)
    {
        bool enableBool = enable == 1;
        _joystick.gameObject.SetActive(enableBool);
        _shootButton.gameObject.SetActive(enableBool);
        _superWeaponButton.gameObject.SetActive(enableBool);
    }

    public void UIKeyShootPressed()
    {
        KeyShootPressed?.Invoke();
    }

    public void UIKeySuperShootPressed()
    {
        KeySuperShootPressed?.Invoke();
    }

    private void UpdateCanShoot(bool isPaused)
    {
        _canShoot = !isPaused;
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playerMover.TryMoveUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            _playerMover.TryMoveDown();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerMover.TryMoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerMover.TryMoveLeft();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _playerMover.StopMove();
        }

        if (Input.GetKey(KeyCode.Return) && Time.time >= _nextShootTime && _canShoot)
        {
            KeyShootPressed?.Invoke();
            _nextShootTime = Time.time + shootDelay;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
        {
             KeySuperShootPressed?.Invoke();
        }
    }
}

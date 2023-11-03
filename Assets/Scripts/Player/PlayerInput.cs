using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private ShootButton _shootButton;
    [SerializeField] private SuperWeaponButton _superWeaponButton;

    public event UnityAction KeyShootPressed;
    public event UnityAction KeySuperShootPressed;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        InputHandler();
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            KeyShootPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
             KeySuperShootPressed?.Invoke();
        }
    }
}

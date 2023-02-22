using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    public event UnityAction keyFirePressed;
    public event UnityAction keySuperFirePressed;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        InputHandler();
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
            keyFirePressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keySuperFirePressed?.Invoke();
        }
    }
}

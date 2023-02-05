using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private float _elapsedTime;
    private float _shootDelay = 0.15f;

    public event UnityAction keyFirePressed;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        InputHandler();
        _elapsedTime += Time.deltaTime;
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

        if (Input.GetKeyDown(KeyCode.Return) && _elapsedTime > _shootDelay)
        {
            keyFirePressed?.Invoke();
            _elapsedTime = 0f;
        }
    }
}

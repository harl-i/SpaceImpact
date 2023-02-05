using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }

    private bool _isHorizontalMove;
    private bool _isVerticalMove;
    private float _elapsedTime;
    private float _shootDelay = 0.15f;

    public event UnityAction keyFirePressed;

    private void Update()
    {
        InputHandler();
        _elapsedTime += Time.deltaTime;
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.W) && !_isHorizontalMove)
        {
            MoveDirection = new Vector2(0, 1);
            _isVerticalMove = true;
        }

        if (Input.GetKey(KeyCode.S) && !_isHorizontalMove)
        {
            MoveDirection = new Vector2(0, -1);
            _isVerticalMove = true;
        }

        if (Input.GetKey(KeyCode.D) && !_isVerticalMove)
        {
            MoveDirection = new Vector2(1, 0);
            _isHorizontalMove = true;
        }

        if (Input.GetKey(KeyCode.A) && !_isVerticalMove)
        {
            MoveDirection = new Vector2(-1, 0);
            _isHorizontalMove = true;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            MoveDirection = Vector2.zero;
            _isVerticalMove = false;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            MoveDirection = Vector2.zero;
            _isHorizontalMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) && _elapsedTime > _shootDelay)
        {
            keyFirePressed?.Invoke();
            _elapsedTime = 0f;
        }
    }
}

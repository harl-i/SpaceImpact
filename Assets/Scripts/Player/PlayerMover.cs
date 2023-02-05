using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxWidth;

    private float _stepSize = 0.2f;
    private Vector2 _targetPosition;
    private bool _isVerticalMove;
    private bool _isHorizontalMove;

    public void TryMoveUp()
    {
        if(!_isHorizontalMove && _targetPosition.y < _maxHeight)
        {
            SetNextPosition(Vector2.up);
            _isVerticalMove = true;
        }
    }

    public void TryMoveDown()
    {
        if (!_isHorizontalMove && transform.position.y > _minHeight)
        {
            SetNextPosition(Vector2.down);
            _isVerticalMove = true;
        }
    }

    public void TryMoveLeft()
    {
        if (!_isVerticalMove && transform.position.x > _minWidth)
        {
            SetNextPosition(Vector2.left);
            _isHorizontalMove = true;
        }
    }

    public void TryMoveRight()
    {
        if (!_isVerticalMove && transform.position.x < _maxWidth)
        {
            SetNextPosition(Vector2.right);
            _isHorizontalMove = true;
        }
    }

    public void StopMove()
    {
        _isVerticalMove = false;
        _isHorizontalMove = false;
    }

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if ((Vector2)transform.position != _targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }  
    }

    private void SetNextPosition(Vector2 direction)
    {
        _targetPosition = (Vector2)transform.position + direction * _stepSize;
    }
}

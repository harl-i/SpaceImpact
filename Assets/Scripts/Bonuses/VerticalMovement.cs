using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _amplitude = 1f;
    private float _originalY;
    private float _newPositionY;

    private void Start()
    {
        _originalY = gameObject.transform.position.y;
    }

    private void Update()
    {
        _newPositionY = _originalY + _amplitude * Mathf.Sin(Time.time * _speed);

        transform.position = new Vector3(
            transform.position.x,
            _newPositionY, 
            transform.position.z);
    }
}

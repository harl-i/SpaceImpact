using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(VerticalMovement))]
public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected int _count;
    [SerializeField] protected VerticalMovement _verticalMovement;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _verticalMovement = GetComponent<VerticalMovement>();
    }

    private void Update()
    {
        Move();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void ActivateVertcalMovement()
    {
        _verticalMovement.enabled = true;
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}

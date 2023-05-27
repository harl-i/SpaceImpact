using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(VerticalMovement))]
public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected int _count;
    [SerializeField] protected VerticalMovement _verticalMovement;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void ActivateVertcalMovement()
    {
        _verticalMovement.enabled = true;
    }

    private void OnEnable()
    {
        _verticalMovement = GetComponent<VerticalMovement>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}

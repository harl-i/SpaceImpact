using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected int _count;

    public void SetSpeed(float speed)
    {
        _speed = speed;
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

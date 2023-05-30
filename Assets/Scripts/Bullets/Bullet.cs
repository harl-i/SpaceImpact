using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IObjectFromPool
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private Direction _choiceDirection;

    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent.transform;
    }

    private void OnEnable()
    {
        SetDirection(_choiceDirection);
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
    
    public void ReturnToPool()
    {
        if (transform.parent == null)
        {
            transform.SetParent(_parent);
        }

        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    private void SetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                StartCoroutine(Shoot(Vector2.left, _bulletLifeTime));
                break;
            case Direction.Right:
                StartCoroutine(Shoot(Vector2.right, _bulletLifeTime));
                break;
            default:
                break;
        }
    }

    private IEnumerator Shoot(Vector2 direction, float lifetime)
    {
        float timeAfterEnable = 0;

        while (timeAfterEnable < lifetime)
        {
            this.transform.Translate(direction * _bulletSpeed * Time.deltaTime);
            timeAfterEnable += Time.deltaTime;

            yield return null;
        }

        ReturnToPool();
    }
}

enum Direction
{
    Left,
    Right
}

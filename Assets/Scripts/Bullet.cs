using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private Direction _choiceDirection;

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Disable();
    }

    private void OnEnable()
    {
        SetDirection(_choiceDirection);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
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

        Disable();
    }
}

enum Direction
{
    Left,
    Right
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class LevelEndBehaviour : MonoBehaviour
{
    private Vector3 _targetFirst;
    private Vector3 _targetSecond;
    private PolygonCollider2D _collider;
    private float _verticalSpeed = 2f;
    private float _horizontalSpeed = 4f;
    private Vector2 _position = new Vector2(12f, 1.7f);

    private void Awake()
    {
        _collider = GetComponent<PolygonCollider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Leaving());
    }

    private IEnumerator Leaving()
    {
        _collider.enabled = false;
        _targetFirst = new Vector3(transform.position.x, _position.y, transform.position.z);

        while (transform.position != _targetFirst)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetFirst, Time.deltaTime * _verticalSpeed);
            yield return null;
        }

        _targetSecond = new Vector3(_position.x, transform.position.y, transform.position.z);

        while (transform.position != _targetSecond)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetSecond, Time.deltaTime * _horizontalSpeed);
            _horizontalSpeed += 0.1f;
            yield return null;
        }
        _collider.enabled = true;
    }
}

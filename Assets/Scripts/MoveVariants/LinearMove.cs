using System.Collections;
using UnityEngine;

public class LinearMove : Move
{
    private float _speed;
    private Coroutine _startMove;

    private void OnEnable()
    {
        _startMove = StartCoroutine(StartMove());
    }

    private void OnDisable()
    {
        if (_startMove != null)
        {
            StopCoroutine(_startMove);
        }
    }

    public override void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public override IEnumerator StartMove()
    {
        while (gameObject.activeSelf == true)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeMove : Move
{
    private List<GameObject> _points = new List<GameObject>();
    private float _speed;
    private Coroutine _startMove;
    private float _attackSpeed = 4;

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

    public void SetPoints(List<GameObject> points)
    {
        _points = points;
    }

    public override IEnumerator StartMove()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            if (i == 2)
            {
                _speed *= _attackSpeed;
            }

            if (i == 3)
            {
                _speed /= _attackSpeed; 
            }

            yield return MoveToTarget(_points[i].transform.position);
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : Move
{
    private List<GameObject> _points = new List<GameObject>();
    private float _speed;
    private Vector3 _target;
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

    public void SetPoints(List<GameObject> points)
    {
        _points = points;
    }

    public override IEnumerator StartMove()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _target = _points[i].transform.position;

            while (transform.position != _target)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed);
                yield return null;
            }

            if (i == _points.Count - 1)
                i = 0;
        }
    }
}

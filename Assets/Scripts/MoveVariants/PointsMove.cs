using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMove : Move
{
    private List<GameObject> _points = new List<GameObject>();
    private float _speed;

    public void SetPoints(List<GameObject> points)
    {
        _points = points;
    }

    public override void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public override IEnumerator StartMove()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            yield return StartCoroutine(MoveToTarget(_points[i].transform.position));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartMove());
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

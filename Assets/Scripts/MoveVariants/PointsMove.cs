using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMove : Move
{
    private List<GameObject> _points = new List<GameObject>();

    public void SetPoints(List<GameObject> points)
    {
        _points = points;
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
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 1.7f);
            yield return null;
        }
    }
}

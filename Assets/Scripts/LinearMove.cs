using System.Collections;
using UnityEngine;

public class LinearMove : Move
{
    private float _speed = 2f;

    private void OnEnable()
    {
        StartCoroutine(StartMove());
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

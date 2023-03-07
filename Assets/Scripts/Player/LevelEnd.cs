using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private Vector3 _targetFirst;
    private Vector3 _targetSecond;
    private float positionY = 1.7f;
    private float positionX = 12f;
    private float verticalSpeed = 2f;
    private float horizontalSpeed = 4f;

    private void Start()
    {
        StartCoroutine(Leaving());
    }

    private IEnumerator Leaving()
    {
        _targetFirst = new Vector3(transform.position.x, positionY, transform.position.z);

        while (transform.position != _targetFirst)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetFirst, Time.deltaTime * verticalSpeed);
            yield return null;
        }

        _targetSecond = new Vector3(positionX, transform.position.y, transform.position.z);

        while (transform.position != _targetSecond)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetSecond, Time.deltaTime * horizontalSpeed);
            horizontalSpeed += 0.1f;
            yield return null;
        } 
    }
}

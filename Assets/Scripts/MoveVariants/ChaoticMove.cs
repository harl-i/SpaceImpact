using System.Collections;
using UnityEngine;

public class ChaoticMove : Move
{
    private float _topBorder = 1.65f;
    private float _bottomBorder = -3.55f;
    private float _offsetX = 3.3f;

    private void OnEnable()
    {
        StartCoroutine(StartMove());
    }

    public override IEnumerator StartMove()
    {
        while (gameObject.activeSelf == true)
        {
            float random = Random.Range(_bottomBorder, _topBorder);
            
            Vector3 target = new Vector3(
                transform.position.x - _offsetX, 
                Mathf.Clamp(transform.position.y + random, _bottomBorder, _topBorder),
                transform.position.z);
            

            while (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 1.25f);
                yield return null;
            }

        }
    }
}

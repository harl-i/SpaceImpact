using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightPulse : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    private Light2D _light2D;
    private float _maxTime = 1f;

    private void Awake()
    {
        _light2D = GetComponent<Light2D>();
    }

    void Start()
    {
        StartCoroutine(ChangeRadius());
    }

    IEnumerator ChangeRadius()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);

        while (true)
        {
            float targetRadius = Random.Range(_minValue, _maxValue);
            float elapsedTime = 0f;
            float startRadius = _light2D.pointLightOuterRadius;

            while (elapsedTime < _maxTime)
            {
                elapsedTime += Time.deltaTime * _speed;
                _light2D.pointLightOuterRadius = Mathf.Lerp(startRadius, targetRadius, elapsedTime);
                yield return null;
            }

            yield return delay;
        }
    }
}

using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _time;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _minAlphaValue = 0f;
    private float _alpha;

    public float BlinkingTime => _time;

    private void Update()
    {
        Blinking();
    }

    private void Blinking()
    {
        _alpha = Mathf.PingPong(Time.time * _speed, 1) + _minAlphaValue;

        _spriteRenderer.color = new Color(
            _spriteRenderer.color.r,
            _spriteRenderer.color.g,
            _spriteRenderer.color.b, _alpha);
    }

    private void OnEnable()
    {
        _spriteRenderer.color = new Color(
            _spriteRenderer.color.r,
            _spriteRenderer.color.g,
            _spriteRenderer.color.b, 0);
    }

    private void OnDisable()
    {
        _spriteRenderer.color = new Color(
            _spriteRenderer.color.r,
            _spriteRenderer.color.g,
            _spriteRenderer.color.b, 1f);
    }
}

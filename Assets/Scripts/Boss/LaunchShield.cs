using UnityEngine;

public class LaunchShield : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}

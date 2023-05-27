using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 1f;
    private float originalY;

    void Start()
    {
        originalY = gameObject.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + amplitude * Mathf.Sin(Time.time * speed), transform.position.z);
    }
}

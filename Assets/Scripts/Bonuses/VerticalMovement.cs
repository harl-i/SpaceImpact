using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 1f;
    private float originalY;
    private float newPositionY;

    private void Start()
    {
        originalY = gameObject.transform.position.y;
    }

    private void Update()
    {
        newPositionY = originalY + amplitude * Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(
            transform.position.x,
            newPositionY, 
            transform.position.z);
    }
}

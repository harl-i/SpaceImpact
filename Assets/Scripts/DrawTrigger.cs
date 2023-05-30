using UnityEngine;

public class DrawTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Color _color;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;

        Vector2 triggerPosition = new Vector2(transform.position.x, transform.position.y);

        Gizmos.DrawCube(triggerPosition + _boxCollider2D.offset, _boxCollider2D.size);
    }
}

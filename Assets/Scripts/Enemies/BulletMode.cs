using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(MoveSwitcher))]
public class BulletMode : MonoBehaviour
{
    private MoveSwitcher _moveSwitcher;
    private List<GameObject> _emptyWaypoints;
    private float _speed = 2.5f;

    private void OnEnable()
    {
        _moveSwitcher = GetComponent<MoveSwitcher>();
        _moveSwitcher.ActivateMoveVariant(MoveVariants.Linear, _speed, _emptyWaypoints);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LinearMove))]
[RequireComponent(typeof(ChaoticMove))]
[RequireComponent(typeof(PointsMove))]
[RequireComponent(typeof(PatrolMove))]
public class MoveSwitcher : MonoBehaviour
{
    private LinearMove _linearMove;
    private ChaoticMove _chaoticMove;
    private PointsMove _pointsMove;
    private PatrolMove _patrolMove;

    public void ActivateMoveVariant(MoveVariants moveVariants, float speed)
    {
        DisableAll();

        switch (moveVariants)
        {
            case MoveVariants.Linear:
                _linearMove.enabled = true;
                _linearMove.SetSpeed(speed);
                break;
            case MoveVariants.Chaotic:
                _chaoticMove.enabled = true;
                _chaoticMove.SetSpeed(speed);
                break;
            case MoveVariants.Points:
                _pointsMove.enabled = true;
                _pointsMove.SetSpeed(speed);
                break;
            case MoveVariants.Patrol:
                _patrolMove.enabled = true;
                _patrolMove.SetSpeed(speed);
                break;
            default:
                break;
        }
    }

    private void DisableAll()
    {
        _linearMove.enabled = false;
        _chaoticMove.enabled = false;
        _pointsMove.enabled = false;
    }

    private void Awake()
    {
        _linearMove = GetComponent<LinearMove>();
        _chaoticMove = GetComponent<ChaoticMove>();
        _pointsMove = GetComponent<PointsMove>();
        _patrolMove = GetComponent<PatrolMove>();
    }
}

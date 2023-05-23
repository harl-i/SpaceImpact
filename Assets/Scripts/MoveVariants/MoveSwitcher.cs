using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LinearMove))]
[RequireComponent(typeof(ChaoticMove))]
[RequireComponent(typeof(PointsMove))]
[RequireComponent(typeof(PatrolMove))]
[RequireComponent(typeof(LungeMove))]
public class MoveSwitcher : MonoBehaviour
{
    private LinearMove _linearMove;
    private ChaoticMove _chaoticMove;
    private PointsMove _pointsMove;
    private PatrolMove _patrolMove;
    private LungeMove _lungeMove;

    public void ActivateMoveVariant(MoveVariants moveVariants, float speed, List<GameObject> wayPoints)
    {
        DisableAll();

        switch (moveVariants)
        {
            case MoveVariants.Linear:
                _linearMove.SetSpeed(speed);
                _linearMove.enabled = true;
                break;
            case MoveVariants.Chaotic:
                _chaoticMove.SetSpeed(speed);
                _chaoticMove.enabled = true;
                break;
            case MoveVariants.Points:
                _pointsMove.SetPoints(wayPoints);
                _pointsMove.SetSpeed(speed);
                _pointsMove.enabled = true;
                break;
            case MoveVariants.Patrol:
                _patrolMove.SetPoints(wayPoints);
                _patrolMove.SetSpeed(speed);
                _patrolMove.enabled = true;
                break;
            case MoveVariants.Lunge:
                _lungeMove.SetPoints(wayPoints);
                _lungeMove.SetSpeed(speed);
                _lungeMove.enabled = true;
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
        _patrolMove.enabled = false;
        _lungeMove.enabled = false;
    }

    private void Awake()
    {
        _linearMove = GetComponent<LinearMove>();
        _chaoticMove = GetComponent<ChaoticMove>();
        _pointsMove = GetComponent<PointsMove>();
        _patrolMove = GetComponent<PatrolMove>();
        _lungeMove = GetComponent<LungeMove>();
    }
}

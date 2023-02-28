using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LinearMove))]
[RequireComponent(typeof(ChaoticMove))]
[RequireComponent(typeof(PointsMove))]
public class MoveSwitcher : MonoBehaviour
{
    private LinearMove _linearMove;
    private ChaoticMove _chaoticMove;
    private PointsMove _pointsMove;

    public void ActivateMoveVariant(MoveVariants moveVariants)
    {
        DisableAll();

        switch (moveVariants)
        {
            case MoveVariants.Linear:
                _linearMove.enabled = true;
                break;
            case MoveVariants.Chaotic:
                _chaoticMove.enabled = true;
                break;
            case MoveVariants.Points:
                _pointsMove.enabled = true;
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
    }
}

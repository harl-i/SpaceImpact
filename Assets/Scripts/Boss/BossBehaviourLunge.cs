using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveSwitcher))]
[RequireComponent(typeof(LungeMove))]
[RequireComponent(typeof(PatrolMove))]
public class BossBehaviourLunge : MonoBehaviour
{
    private List<GameObject> _lungeWayPoints = new List<GameObject>();
    private List<GameObject> _patrolWayPoints = new List<GameObject>();
    private MoveSwitcher _moveSwitcher;
    private float _speed = 2f;

    private void Awake()
    {
        _moveSwitcher = GetComponent<MoveSwitcher>();
    }

    private void Start()
    {
        StartCoroutine(StartBehaviour());
    }

    public void SetLungeBehaviourWaypoints(List<GameObject> patrolWaypoints, List<GameObject> lungeWaypoints)
    {
        _patrolWayPoints = patrolWaypoints;
        _lungeWayPoints = lungeWaypoints;
    }

    private IEnumerator StartBehaviour()
    {
        WaitForSeconds delayAfterPatrolMoveActivation = new WaitForSeconds(16f);
        WaitForSeconds delayAfterLungeMoveActivation = new WaitForSeconds(7f);

        while (gameObject.activeSelf == true)
        {
            _moveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, _speed, _patrolWayPoints);

            yield return delayAfterPatrolMoveActivation;

            _moveSwitcher.ActivateMoveVariant(MoveVariants.Lunge, _speed, _lungeWayPoints);

            yield return delayAfterLungeMoveActivation;
        }
    }
}

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
    //private LungeMove _lungeMove;
    //private PatrolMove _patrolMove;

    public void SetLungeBehaviourWaypoints(List<GameObject> patrolWaypoints, List<GameObject> lungeWaypoints)
    {
        _patrolWayPoints = patrolWaypoints;
        _lungeWayPoints = lungeWaypoints;
    }

    private void Awake()
    {
        _moveSwitcher = GetComponent<MoveSwitcher>();
        //_lungeMove = GetComponent<LungeMove>();
        //_patrolMove = GetComponent<PatrolMove>();
    }

    private void Start()
    {
        //_lungeMove.SetPoints(_lungeWayPoints);
        //_patrolMove.SetPoints(_patrolWayPoints);

        StartCoroutine(StartBehaviour());
    }

    private IEnumerator StartBehaviour()
    {
        while (gameObject.activeSelf == true)
        {
            _moveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, 2f, _patrolWayPoints);

            yield return new WaitForSeconds(16f);

            _moveSwitcher.ActivateMoveVariant(MoveVariants.Lunge, 2f, _lungeWayPoints);

            yield return new WaitForSeconds(7f);
        }
    }
}

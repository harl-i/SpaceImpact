using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveSwitcher))]
[RequireComponent(typeof(LungeMove))]
[RequireComponent(typeof(PatrolMove))]
public class BossBehaviourLunge : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lungeWayPoints = new List<GameObject>();
    [SerializeField] private List<GameObject> _patrolWayPoints = new List<GameObject>();
    private MoveSwitcher _moveSwitcher;
    private LungeMove _lungeMove;
    private PatrolMove _patrolMove;

    private void Awake()
    {
        _moveSwitcher = GetComponent<MoveSwitcher>();
        _lungeMove = GetComponent<LungeMove>();
        _patrolMove = GetComponent<PatrolMove>();
    }

    private void Start()
    {
        _lungeMove.SetPoints(_lungeWayPoints);
        _patrolMove.SetPoints(_patrolWayPoints);

        StartCoroutine(StartBehaviour());
    }

    private IEnumerator StartBehaviour()
    {
        while (gameObject.activeSelf == true)
        {
            _moveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, 2f);

            yield return new WaitForSeconds(16f);

            _moveSwitcher.ActivateMoveVariant(MoveVariants.Lunge, 2f);

            yield return new WaitForSeconds(7f);
        }
    }
}

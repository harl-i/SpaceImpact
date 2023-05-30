using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Wave : MonoBehaviour
{
    [SerializeField] protected float _spawnDelay;
    [SerializeField] protected float _enemiesSpeed;
    [SerializeField] protected EnemyPool _enemiesPool;
    [SerializeField] protected List<SpawnPoint> _spawnPoints;
    [SerializeField] protected MoveVariants _moveVariant;
    [SerializeField] protected bool _isBossWave;
    [SerializeField] protected Boss _boss;
    [SerializeField] protected bool _canLunge;
    [SerializeField] protected bool _hasSecondaryWeapon;
    [SerializeField] protected bool _hasBonus;
    [SerializeField] protected BossBehaviourLunge _lungeBehaviour;
    [SerializeField] protected BossBehaviourSecondaryWeapon _bossBehaviourSecondaryWeapon;
    [SerializeField] protected Bonus _bonus;
    [SerializeField] protected float _bonusSpeed;
    [SerializeField] protected bool _canVerticalMoveBonus;
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] private ObjectPool _bossSecondaryWeaponBullets;
    [SerializeField] private List<GameObject> _waypoints = new List<GameObject>();
    [SerializeField] private List<GameObject> _lungeWaypoints = new List<GameObject>();

    private float _bossSpeed = 2f;

    public void StartWave(Wave wave)
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void EndWave()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }
    }

    public Wave GetNextWave()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetWave;
        }

        return null;
    }

    protected void SpawnEnemy(EnemyPool enemiesPool, SpawnPoint spawnPoint, MoveVariants moveVariants)
    {
        enemiesPool.TryGetObject(out GameObject result);

        if (result != null)
        {
            result.GetComponent<MoveSwitcher>().ActivateMoveVariant(moveVariants, _enemiesSpeed, _waypoints);
            result.transform.position = spawnPoint.transform.position;
            result.SetActive(true);
        }
        else
        {
            Debug.Log("Enemys pool is empty");
        }
    }

    protected void SpawnBoss(Boss boss, bool canLunge, bool hasSecondaryWeapon)
    {
        if (canLunge == false && hasSecondaryWeapon == false)
        {
            ActivateBaseBossBehaviour(boss);
        }
        else if (canLunge == true && hasSecondaryWeapon == false)
        {
            ActivateLungeBossBehaviour(boss);
        }
        else if (canLunge == false && hasSecondaryWeapon == true)
        {
            ActivateSecondaryWeaponBossBehaviour(boss);
        }
        else if (canLunge == true && hasSecondaryWeapon == true)
        {
            ActivateLungeAndSecondaryWeaponBossBehaviours(boss);
        }
    }

    protected void SpawnBonus(Bonus bonus, SpawnPoint spawnPointPosition, float speed, bool canVerticalMove)
    {
        var result = Instantiate(bonus, spawnPointPosition.transform);
        result.SetSpeed(speed);
        if (canVerticalMove)
        {
            result.ActivateVertcalMovement();
        }
    }

    private void ActivateLungeAndSecondaryWeaponBossBehaviours(Boss levelBoss)
    {
        levelBoss.gameObject.SetActive(true);
        levelBoss.LungeBehaviour.SetLungeBehaviourWaypoints(_waypoints, _lungeWaypoints);
        levelBoss.LungeBehaviour.enabled = true;
        levelBoss.SecondaryWeapon.enabled = true;
    }

    private void ActivateSecondaryWeaponBossBehaviour(Boss levelBoss)
    {
        levelBoss.gameObject.SetActive(true);
        levelBoss.LungeBehaviour.enabled = false;
        levelBoss.MoveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, _bossSpeed, _waypoints);
        levelBoss.SecondaryWeapon.enabled = true;
    }

    private void ActivateLungeBossBehaviour(Boss levelBoss)
    {
        levelBoss.gameObject.SetActive(true);
        levelBoss.LungeBehaviour.SetLungeBehaviourWaypoints(_waypoints, _lungeWaypoints);
        levelBoss.LungeBehaviour.enabled = true;
    }

    private void ActivateBaseBossBehaviour(Boss levelBoss)
    {
        levelBoss.gameObject.SetActive(true);
        levelBoss.MoveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, _bossSpeed, _waypoints);
    }
}
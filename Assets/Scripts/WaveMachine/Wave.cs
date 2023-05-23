using System.Collections;
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
    [SerializeField] protected BossBehaviourLunge _lungeBehaviour;
    [SerializeField] protected BossBehaviourSecondaryWeapon _bossBehaviourSecondaryWeapon;
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

    protected IEnumerator SpawnEnemy(EnemyPool enemiesPool, float spawnDelay, int enemiesCount, Vector3 spawnPoint, MoveVariants moveVariants)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemiesPool.TryGetObject(out GameObject result);

            if (result != null)
            {
                result.GetComponent<MoveSwitcher>().ActivateMoveVariant(moveVariants, _enemiesSpeed, _waypoints);
                result.transform.position = spawnPoint;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }
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

    protected IEnumerator SpawnBonus(Bonus bonus, float spawnDelay, SpawnPoint spawnPointPosition)
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(bonus, spawnPointPosition.transform);
    }

    private void ActivateLungeAndSecondaryWeaponBossBehaviours(Boss boss)
    {
        boss.gameObject.SetActive(true);
        boss.LungeBehaviour.SetLungeBehaviourWaypoints(_waypoints, _lungeWaypoints);
        boss.LungeBehaviour.enabled = true;
        boss.SecondaryWeapon.enabled = true;
    }

    private void ActivateSecondaryWeaponBossBehaviour(Boss boss)
    {
        boss.gameObject.SetActive(true);
        boss.LungeBehaviour.enabled = false;
        boss.MoveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, _bossSpeed, _waypoints);
        boss.SecondaryWeapon.SetWeapon(_bossSecondaryWeaponBullets);
        boss.SecondaryWeapon.enabled = true;
    }

    private void ActivateLungeBossBehaviour(Boss boss)
    {
        boss.gameObject.SetActive(true);
        boss.LungeBehaviour.SetLungeBehaviourWaypoints(_waypoints, _lungeWaypoints);
        boss.LungeBehaviour.enabled = true;
    }

    private void ActivateBaseBossBehaviour(Boss boss)
    {
        boss.gameObject.SetActive(true);
        boss.MoveSwitcher.ActivateMoveVariant(MoveVariants.Patrol, _bossSpeed, _waypoints);
    }
}
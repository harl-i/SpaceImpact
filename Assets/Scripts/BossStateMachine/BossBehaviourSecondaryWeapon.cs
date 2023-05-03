using System.Collections;
using UnityEngine;

public class BossBehaviourSecondaryWeapon : MonoBehaviour
{
    [SerializeField] private float _firstShootDelay;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private ObjectPool _secondaryWeapon;

    private void Awake()
    {
        _secondaryWeapon = FindObjectOfType<BossRocketsPool>();
    }

    private void Shoot()
    {
        _secondaryWeapon.TryGetObject(out GameObject bullet);

        if (bullet != null)
        {
            bullet.transform.position = _shootPoint.transform.position;
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("bullets pool is empty");
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartShoot(_firstShootDelay));
    }

    private IEnumerator StartShoot(float firstShootDelay)
    {
        yield return new WaitForSeconds(firstShootDelay);

        Shoot();

        yield return new WaitForSeconds(_shootDelay);

        StartCoroutine(Shooting(_shootDelay));
    }

    private IEnumerator Shooting(float delay)
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(delay);
        }
    }
}

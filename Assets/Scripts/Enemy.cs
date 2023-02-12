using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : SpaceFlyingObject, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _reward;
    [SerializeField] private float _firstShootDelay;

    public static event UnityAction EnemyDying;
    public static event UnityAction<int> RewardAccrual;

    private void Awake()
    {
        _bulletsPool = FindObjectOfType<EnemyBulletsPool>().GetComponent<BulletsPool>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartShoot(_firstShootDelay));
    }

    public void Disable()
    {
        EnemyDying?.Invoke();
        RewardAccrual?.Invoke(_reward);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
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

            yield return new WaitUntil(() => gameObject.activeSelf == true);
        }
    }
}

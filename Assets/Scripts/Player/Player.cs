using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour, IShootable
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletsPool _bulletsPool;

    private Rigidbody2D _rb2d;
    private PlayerInput _input;

    private void Awake()
    {
        _bulletsPool = FindObjectOfType<BulletsPool>();

        _rb2d = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.keyFirePressed += OnShoot;
    }

    private void OnDisable()
    {
        _input.keyFirePressed -= OnShoot;
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _input.MoveDirection * _speed;
        
    }

    public void Shoot()
    {
            GameObject bullet;
            _bulletsPool.TryGetObject(out bullet);

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

    private void OnShoot()
    {
        Shoot();
    }
}

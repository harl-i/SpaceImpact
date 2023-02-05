using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : SpaceFlyingObject
{
    private PlayerInput _input;

    private void Awake()
    {
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

    private void OnShoot()
    {
        Shoot();
    }
}

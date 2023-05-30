using UnityEngine;

public class RocketsPool : ObjectPool
{
    [SerializeField] private Rocket _rocket;

    private void Awake()
    {
        Initialize(_rocket);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketsPool : ObjectPool
{
    [SerializeField] private Rocket _rocket;

    private void Awake()
    {
        Initialize(_rocket);
    }
}

using UnityEngine;

public class LasersPool : ObjectPool
{
    [SerializeField] private Laser _laser;

    private void Awake()
    {
        Initialize(_laser);
    }
}

using UnityEngine;

public class LaserWallPool : ObjectPool
{
    [SerializeField] private LaserWall _laserWall;

    private void Awake()
    {
        Initialize(_laserWall);
    }
}

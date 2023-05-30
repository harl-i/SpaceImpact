using System;
using UnityEngine;

public class EnemyDeathNotifier : MonoBehaviour
{
    public static event Action EnemyKilled;

    public void Notify()
    {
        EnemyKilled?.Invoke();
    }
}

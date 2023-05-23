using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathNotifier : MonoBehaviour
{
    public static event Action EnemyKilled;

    public void Notify()
    {
        EnemyKilled?.Invoke();
    }
}

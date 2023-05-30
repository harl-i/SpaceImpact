using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossDeathNotifier : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEvents.Instance.OnBossDied();
    }
}

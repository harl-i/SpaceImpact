using UnityEngine;

public class BossDieBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEvents.Instance.OnBossDied();
    }
}

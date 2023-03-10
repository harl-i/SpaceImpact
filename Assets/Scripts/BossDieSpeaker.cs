using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossDieSpeaker : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEvents.Instance.OnBossDied();
    }
}

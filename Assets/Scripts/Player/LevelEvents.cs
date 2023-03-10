using UnityEngine;
using UnityEngine.Events;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] private LevelEventsListener _playerListener;

    public static LevelEvents Instance { get; set; }

    public event UnityAction LevelBossDied;

    private void Awake()
    {
        Instance = this;
    }

    public void OnBossDied()
    {
        LevelBossDied.Invoke();
    }
}

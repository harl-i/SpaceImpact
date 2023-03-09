using UnityEngine;
using UnityEngine.Events;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] private LevelEventsListener _playerListener;

    public static LevelEvents Instance { get; set; }

    //[SerializeField] private TransitionBossDie _bossDieTransition;

    //private BossDieBehaviour _levelBoss;

    public event UnityAction LevelBossDied;


    private void Awake()
    {
        Instance = this;
        //_levelBoss = GetComponent<BossDieBehaviour>();
        //_levelBoss = GameObject.Find("Boss_1").GetComponent<BossDieBehaviour>();
        //_levelBoss = objec
    }

    private void OnEnable()
    {
        //_bossDieTransition.Died += OnBossDied;
        //_levelBoss.Died += OnBossDied;
    }

    private void OnDisable()
    {
        //_bossDieTransition.Died -= OnBossDied;
        //_levelBoss.Died -= OnBossDied;
    }

    public void OnBossDied()
    {
        LevelBossDied.Invoke();
    }
}

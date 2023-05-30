using UnityEngine;

public class FinalBossBehaviour : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _bossCollider;
    [SerializeField] private BossShield _firstShield;
    [SerializeField] private BossShield _secondShield;

    private void Update()
    {
        if (_firstShield.enabled == false && _secondShield.enabled == false)
        {
            _bossCollider.enabled = true;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(BossBehaviourLunge))]
[RequireComponent(typeof(BossBehaviourSecondaryWeapon))]
[RequireComponent(typeof(MoveSwitcher))]
public class Boss : MonoBehaviour
{
    private BossBehaviourLunge _lungeBehaviour;
    private BossBehaviourSecondaryWeapon _secondaryWeapon;
    private MoveSwitcher _moveSwitcher;

    public BossBehaviourLunge LungeBehaviour => _lungeBehaviour;
    public BossBehaviourSecondaryWeapon SecondaryWeapon => _secondaryWeapon;
    public MoveSwitcher MoveSwitcher => _moveSwitcher;

    private void OnEnable()
    {
        _lungeBehaviour = GetComponent<BossBehaviourLunge>();
        _secondaryWeapon = GetComponent<BossBehaviourSecondaryWeapon>();
        _moveSwitcher = GetComponent<MoveSwitcher>();
    }
}

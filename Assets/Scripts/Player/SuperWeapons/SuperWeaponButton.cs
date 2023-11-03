using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SuperWeaponButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _rocketGunIcon;
    [SerializeField] private Sprite _laserGunIcon;
    [SerializeField] private Sprite _laserWallGunIcon;

    private Animator _animator;
    private bool _hasSuperWeapon;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 1)
        {
            _hasSuperWeapon = false;
        }
    }

    private void OnEnable()
    {
        _player.SuperWeaponChargeDepleted += OnSuperWeaponChargeEmpty;
    }

    private void OnDisable()
    {
        _player.SuperWeaponChargeDepleted -= OnSuperWeaponChargeEmpty;
    }

    public void OnSuperWeaponChargeEmpty()
    {
        Hide();
        _hasSuperWeapon = false;
    }

    public void SetSuperWeapon(SuperWeaponVariant superWeaponVariant)
    {
        StartCoroutine(SwapSuperWeaponButton(superWeaponVariant));
    }

    public void OnStateExit()
    {
        _animator.SetBool("IsPoppingUp", false);
        _animator.SetBool("IsPoppingDown", false);
    }

    private IEnumerator SwapSuperWeaponButton(SuperWeaponVariant superWeaponVariant)
    {
        if (_hasSuperWeapon)
        {
            Hide();

            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        }

        switch (superWeaponVariant)
        {
            case SuperWeaponVariant.Rocket:
                _icon.sprite = _rocketGunIcon;
                break;
            case SuperWeaponVariant.Laser:
                _icon.sprite = _laserGunIcon;
                break;
            case SuperWeaponVariant.LaserWall:
                _icon.sprite = _laserWallGunIcon;
                break;
            default:
                break;
        }

        Reveal();
    }

    private void Reveal()
    {
        _hasSuperWeapon = true;
        _animator.SetBool("IsPoppingUp", true);
    }

    private void Hide()
    {
        _animator.SetBool("IsPoppingDown", true);
    }
}
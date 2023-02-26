using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperWeaponUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _iconInUI;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private Sprite _iconRocket;
    [SerializeField] private Sprite _iconLaser;
    [SerializeField] private Sprite _iconLaserWall;

    private SuperWeaponSwitcher _switcher;

    private void Awake()
    {
        _switcher = _player.GetComponent<SuperWeaponSwitcher>();
    }

    private void OnEnable()
    {
        _switcher.SwitchSuperWeapon += OnWeaponEnable;
        _player.SuperShoot += OnSuperWeaponCountChanged;
    }

    private void OnDisable()
    {
        _switcher.SwitchSuperWeapon -= OnWeaponEnable;
        _player.SuperShoot -= OnSuperWeaponCountChanged;
    }


    private void OnWeaponEnable(SuperWeaponVariant variant)
    {
        switch (variant)
        {
            case SuperWeaponVariant.Rocket:
                _iconInUI.sprite = _iconRocket;
                _count.text = _player.RocketsCount.ToString();
                break;
            case SuperWeaponVariant.Laser:
                _iconInUI.sprite = _iconLaser;
                _count.text = _player.LasersCount.ToString();
                break;
            case SuperWeaponVariant.LaserWall:
                _iconInUI.sprite = _iconLaserWall;
                _count.text = _player.LaserWallsCount.ToString();
                break;
            default:
                break;
        }
    }

    private void OnSuperWeaponCountChanged(int count)
    {
        _count.text = count.ToString();
    }

}

public class WaveBoss : Wave
{
    private void OnEnable()
    {
        SpawnBoss(_boss, _canLunge, _hasSecondaryWeapon);
    }
}
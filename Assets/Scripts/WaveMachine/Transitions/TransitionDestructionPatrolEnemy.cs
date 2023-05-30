public class TransitionDestructionPatrolEnemy : Transition
{
    private void OnEnable()
    {
        EnemyDeathNotifier.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        EnemyDeathNotifier.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        NeedTransit = true;
    }
}

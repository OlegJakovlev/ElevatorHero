using Entity.Health;
using Entity.Health.PlayerHealth;

namespace SpawnManager.Entity
{
    public class PlayerSpawner : AggressiveSpawner
    {
        protected override void Start()
        {
            base.Start();

            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                // If entity is player, respawn on damage taken
                if (entity.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.OnDamageTaken += () => Invoke(nameof(ReduceActiveEntities), _timeForRespawn);
                    playerHealth.OnDeath += () => Active = false;
                }
            }
        }
    }
}
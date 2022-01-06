using Entity.Health;

namespace SpawnManager.Entity
{
    public class CitizenSpawner : EntitySpawner
    {
        protected override void Start()
        {
            base.Start();
            
            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                // If entity is player, respawn on damage taken
                if (entity.TryGetComponent(out EntityHealth playerHealth))
                {
                    playerHealth.OnDeath += () =>  _score.PlayerKillCitizen();
                }
            }
        }
    }
}
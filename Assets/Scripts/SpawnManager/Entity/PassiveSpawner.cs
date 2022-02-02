using Components.Health;

namespace SpawnManager.Entity
{
    public class PassiveSpawner : EntitySpawner
    {
        protected override void Start()
        {
            base.Start();
            
            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                // If entity is dead, reduce score
                if (entity.TryGetComponent(out EntityHealth health))
                {
                    health.OnDeath += () => Score.PlayerKillCitizen(entity.transform);
                }
            }

            // Spawn passive NPC only once
            Spawn();
            Active = false;
        }
    }
}
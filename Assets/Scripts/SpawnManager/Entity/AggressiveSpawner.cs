using Components.ProjectileShoot;
using UnityEngine;

namespace SpawnManager.Entity
{
    public class AggressiveSpawner : EntitySpawner
    {
        [Header("Entities pools")]
        [SerializeField] protected ObjectPool.ObjectPool _projectilePool;
        
        protected override void Start()
        {
            base.Start();

            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                // Set projectile pool for entities
                if (entity.TryGetComponent(out Shooting shooting))
                {
                    shooting.SetProjectilePool(_projectilePool);
                }
            }
        }
    }
}
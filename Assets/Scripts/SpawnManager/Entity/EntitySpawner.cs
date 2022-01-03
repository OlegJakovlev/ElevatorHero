using System.Collections.Generic;
using Entity.Health;
using Entity.ProjectileShoot;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager.Entity
{
    public class EntitySpawner : MonoBehaviour, ISpawner
    {
        [Header("Spawner Entity")]
        [SerializeField] private ObjectPool.ObjectPool _entityPool;

        [Header("Spawner Properties")]
        [SerializeField] private float _timeForRespawn = 2f;
        [SerializeField] private int _entitiesSpawnLimit;
        [SerializeField] private List<SpawnPoint> _spawnArea;

        [Header("Entities pools")]
        [SerializeField] private ObjectPool.ObjectPool _projectilePool;

        private bool _active = true;
        private int _spawnedEntities;

        private void Start()
        {
            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                // Set projectile pool for entities
                if (entity.TryGetComponent(out Shooting shooting))
                {
                    shooting.SetProjectilePool(_projectilePool);
                }
            
                // If entity is player, respawn with lower health
                if (entity.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.OnDamageTaken += () => Invoke(nameof(ReduceActiveEntities), _timeForRespawn);
                    playerHealth.OnDeath += () => _active = false;
                }
                else if (entity.TryGetComponent(out EntityHealth entityHealth))
                {
                    entityHealth.OnDeath += () => Invoke(nameof(ReduceActiveEntities), _timeForRespawn);
                }
            }
        }

        private void Update()
        {
            if (_active) Spawn();
        }

        public void Spawn()
        {
            if (_spawnedEntities >= _entitiesSpawnLimit) return;
            if (_spawnArea.Count <= 0)
            {
                Debug.LogWarning("No spawn areas set up!");
                return;
            }

            GameObject newEntity = _entityPool.GetPooledObject();
            if (!newEntity) return;
            
            // Spawn new enemy
            _spawnedEntities++;

            // Teleport to destination and set active
            newEntity.transform.position = GetSpawnArea().GetRandomSpawnPoint();
            newEntity.SetActive(true);
        }

        private SpawnPoint GetSpawnArea()
        {
            if (_spawnArea.Count <= 0) return null;
            return _spawnArea[Random.Range(0, _spawnArea.Count)];
        }

        private void ReduceActiveEntities()
        {
            _spawnedEntities--;
        }
    }
}
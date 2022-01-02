using System;
using System.Collections.Generic;
using Entity.Health;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager
{
    public class EntitySpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private GameObject _entity;
        [SerializeField] private int _entitiesSpawnLimit;
        [SerializeField] private List<SpawnPoint> _spawnArea;
        
        private int _spawnedEntities;

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {
            if (_spawnedEntities > _entitiesSpawnLimit) return;
            
            // Spawn new enemy
            _spawnedEntities++;
            GameObject newEntity = Instantiate(_entity, GetSpawnArea().GetRandomSpawnPoint(), Quaternion.identity);
            
            // Reduce active entities after its death
            if (newEntity.TryGetComponent(out EntityHealth health))
            {
                health.OnDeath += ReduceActiveEntities;
            }
        }

        private SpawnPoint GetSpawnArea()
        {
            return _spawnArea[Random.Range(0, _spawnArea.Count)];
        }

        private void ReduceActiveEntities()
        {
            _spawnedEntities--;
        }
    }
}
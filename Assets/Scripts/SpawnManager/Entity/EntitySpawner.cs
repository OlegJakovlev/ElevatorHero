using System.Collections.Generic;
using Entity.Health;
using Score;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager.Entity
{
    public abstract class EntitySpawner : MonoBehaviour, ISpawner
    {
        [Header("Spawner Entity")]
        [SerializeField] protected ObjectPool.ObjectPool _entityPool;

        [Header("Spawner Properties")]
        [SerializeField] protected float _timeForRespawn = 2f;
        [SerializeField] protected int _entitiesSpawnLimit;
        [SerializeField] protected List<SpawnPoint> _spawnArea;

        [Header("Object properties")]
        [SerializeField] protected ScoreSetup _score;

        protected bool Active = true;
        private int _spawnedEntities;

        protected virtual void Awake()
        {
            if (!_score)
            {
                // Get global controller
                GameObject globalController = GameObject.FindWithTag("GameController");

                if (globalController.TryGetComponent(out ScoreSetup score))
                {
                    _score = score;
                }
            }
        }

        protected virtual void Start()
        {
            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                if (entity.TryGetComponent(out EntityHealth entityHealth))
                {
                    entityHealth.OnDeath += () => Invoke(nameof(ReduceActiveEntities), _timeForRespawn);
                }
            }
        }

        protected void Update()
        {
            if (Active) Spawn();
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

        protected SpawnPoint GetSpawnArea()
        {
            if (_spawnArea.Count <= 0) return null;
            return _spawnArea[Random.Range(0, _spawnArea.Count)];
        }

        protected void ReduceActiveEntities()
        {
            _spawnedEntities--;
        }
    }
}
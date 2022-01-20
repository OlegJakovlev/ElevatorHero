using System.Collections.Generic;
using Components.Health;
using Components.Score;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager.Entity
{
    public abstract class EntitySpawner : MonoBehaviour, ISpawner
    {
        [Header("Spawner Entity")]
        [SerializeField] protected ObjectPool.ObjectPool _entityPool;

        [Header("Spawner Properties")] 
        [SerializeField] protected LayerMask _noSpawnMask;
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

        protected virtual void Update()
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

            // Check if entity spawn overlap happens
            Vector3 entityDimensions = newEntity.transform.localScale;
            Vector3 spawnCoordinates = GetSpawnArea().GetRandomSpawnPoint();

            Collider2D collision = Physics2D.OverlapArea(
                new Vector2(spawnCoordinates.x - entityDimensions.x / 2, spawnCoordinates.y - entityDimensions.y / 2),
                new Vector2(spawnCoordinates.x + entityDimensions.x / 2, spawnCoordinates.y + entityDimensions.y / 2),
                _noSpawnMask
            );

            if (collision != null) return;
            
            // Spawn new entity
            _spawnedEntities++;

            // Teleport to destination and set active
            newEntity.transform.position = spawnCoordinates;
            newEntity.SetActive(true);
        }

        private SpawnPoint GetSpawnArea()
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
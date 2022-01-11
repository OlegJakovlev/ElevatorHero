using Components.Health;
using UnityEngine;

namespace SpawnManager.Entity
{
    public class EnemySpawner : AggressiveSpawner
    {
        [Header("Spawner properties")] 
        [SerializeField] private float _spawnDelayTimer;

        [Header("Alarm settings")]
        [SerializeField] private int _alarmIncreaseAmount;
        private LevelTimer _levelTimer;

        protected override void Awake()
        {
            base.Awake();
            
            // Increase spawn limit on each level alarm
            
            // Get level controller
            GameObject levelController = GameObject.FindWithTag("LevelManager");

            if (levelController.TryGetComponent(out LevelTimer timer))
            {
                _levelTimer = timer;
                _levelTimer.OnAlarm += () => _entitiesSpawnLimit += _alarmIncreaseAmount;
            }

            if (!_levelTimer) Debug.LogWarning("No level timer assigned!");
        }
        
        protected override void Start()
        {
            base.Start();
            
            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                if (entity.TryGetComponent(out EntityHealth entityHealth))
                {
                    entityHealth.OnDeath += () => _score.PlayerKillEnemy();
                }
            }
            
            InvokeRepeating(nameof(Spawn), 0, _spawnDelayTimer);
        }

        protected override void Update()
        {
            // Do nothing
        }
    }
}
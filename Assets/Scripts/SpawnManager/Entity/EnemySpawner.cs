﻿using Entity.Health;
using UnityEngine;

namespace SpawnManager.Entity
{
    public class EnemySpawner : AggressiveSpawner
    {
        [SerializeField] private LevelTimer _levelTimer;
        [SerializeField] private int _alarmIncreaseAmount;

        protected override void Awake()
        {
            base.Awake();
            
            // Increase spawn limit on each level alarm
            if (!_levelTimer)
            {
                // Get level controller
                GameObject levelController = GameObject.FindWithTag("LevelManager");

                if (levelController.TryGetComponent(out LevelTimer timer))
                {
                    _levelTimer = timer;
                    _levelTimer.OnAlarm += () => _entitiesSpawnLimit += _alarmIncreaseAmount;
                }
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
        }
    }
}
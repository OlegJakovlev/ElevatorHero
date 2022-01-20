using Components.Health.PlayerHealth;
using SaveAndLoadSystem.HighScore;
using UnityEngine;

namespace SpawnManager.Entity
{
    public class PlayerSpawner : AggressiveSpawner
    {
        [Header("Object Properties")]
        [SerializeField] private PlayerHealthView _healthView;

        protected override void Awake()
        {
            base.Awake();
            _healthView = GameObject.FindWithTag("PlayerUI").GetComponent<PlayerHealthView>();
        }

        protected override void Start()
        {
            base.Start();

            // Add events only once hence we use object pools
            foreach (var entity in _entityPool.GetAllPooledObjects())
            {
                if (entity.TryGetComponent(out PlayerHealth playerHealth))
                {
                    // Set model for view
                    _healthView.SetModel(playerHealth);
                    
                    // If entity is player, respawn on damage taken
                    playerHealth.OnDamageTaken += () => Invoke(nameof(ReduceActiveEntities), _timeForRespawn);
                    playerHealth.OnDeath += () =>
                    {
                        // Disable respawn
                        Active = false;
                        HighScoreManager.Instance.CheckForHighScore();
                    };
                }
            }
        }
    }
}
using System;
using UnityEngine;

namespace Components.Health
{
    public abstract class EntityHealth : MonoBehaviour, IHealth
    {
        [SerializeField] protected int _maxHealth;
        protected int CurrentHealth;

        public event Action OnDeath;
        public event Action OnDamageTaken;

        protected void Start()
        {
            if (_maxHealth <= 0) Debug.LogWarning("Entity health is less that 0!");
            CurrentHealth = _maxHealth;
        }

        public virtual void AddHealth(int amount)
        {
            if (amount <= 0) return;
            CurrentHealth += amount;
        }

        public virtual void LoseHealth(int amount)
        {
            if (amount <= 0) return;
            
            // Update current health
            CurrentHealth -= amount;
            OnDamageTaken?.Invoke();
            
            // Check for current health
            if (CurrentHealth <= 0) Die();
            
            // Set entity inactive
            gameObject.SetActive(false);
        }

        public virtual void Die()
        {
            OnDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
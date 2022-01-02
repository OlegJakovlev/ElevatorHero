using System;
using UnityEngine;

namespace Entity.Health
{
    public class EntityHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        public Action OnDeath;

        private void Awake()
        {
            if (_maxHealth <= 0) Debug.LogWarning("Entity health is less that 0!");
            _currentHealth = _maxHealth;
        }

        public void AddHealth(int amount)
        {
            if (amount <= 0) return;
            _currentHealth += amount;
        }

        public void LoseHealth(int amount)
        {
            if (amount <= 0) return;
            _currentHealth -= amount;
        }

        public void Die()
        {
            OnDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
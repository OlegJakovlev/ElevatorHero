using System;
using Audio;
using UnityEngine;

namespace Components.Health
{
    [RequireComponent(typeof(Animator))]
    public abstract class EntityHealth : MonoBehaviour, IHealth
    {
        [SerializeField] protected int _maxHealth;
        protected int CurrentHealth;

        [Header("Visuals")]
        [SerializeField] protected AnimationClip _deathClip;
        protected Animator Animator;

        public event Action OnDeath;
        public event Action OnDamageTaken;

        protected void Awake()
        {
            Animator = GetComponent<Animator>();
        }

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
            
            // Play entity hit sound
            AudioSetup.Instance.PlaySound("EntityHit");
            
            // Check for current health
            if (CurrentHealth <= 0) Die();
        }

        public virtual void Die()
        {
            OnDeath?.Invoke();
            AudioSetup.Instance.PlaySound("EntityDie");
            
            // Play death animation if exists
            if (_deathClip) Animator.Play(_deathClip.name);
            else gameObject.SetActive(false);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
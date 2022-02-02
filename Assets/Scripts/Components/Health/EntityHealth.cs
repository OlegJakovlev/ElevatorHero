using System;
using Audio;
using UnityEngine;

namespace Components.Health
{
    [RequireComponent(typeof(Animator))]
    public abstract class EntityHealth : MonoBehaviour, IHealth
    {
        [SerializeField] protected int _maxHealth;
        private int _currentHealth;
        private bool _invincibility;

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
            _currentHealth = _maxHealth;
        }

        protected void OnEnable()
        {
            _invincibility = false;
        }

        public virtual void AddHealth(int amount)
        {
            if (amount <= 0) return;
            _currentHealth += amount;
        }

        public virtual void LoseHealth(int amount)
        {
            if (amount <= 0 || _invincibility) return;

            // Can not obtain more damage than needed
            _invincibility = true;
            
            print(1);
            
            // Update current health
            _currentHealth -= amount;
            OnDamageTaken?.Invoke();
            
            print(2);
            
            // Play entity hit sound
            AudioSetup.Instance.PlaySound("EntityHit");
            
            print(3);

            // Check for current health
            if (_currentHealth <= 0) Die();
        }

        public virtual void Die()
        {
            AudioSetup.Instance.PlaySound("EntityDie");
            
            // Play death animation if exists
            if (_deathClip) Animator.Play(_deathClip.name);
            else Deactivate();
        }

        public void DeathEvent()
        {
            if (_currentHealth <= 0) OnDeath?.Invoke();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
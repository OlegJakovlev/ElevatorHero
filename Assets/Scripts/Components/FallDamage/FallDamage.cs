using Components.Health;
using Components.Health.PlayerHealth;
using UnityEngine;

namespace Components.FallDamage
{
    [RequireComponent(typeof(PlayerHealth))]
    public class FallDamage : MonoBehaviour
    {
        [SerializeField] private float _maxVerticalVelocity = 10f;
        private EntityHealth _health;

        private void Awake()
        {
            _health = GetComponent<EntityHealth>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.relativeVelocity.y > _maxVerticalVelocity)
            {
                _health.LoseHealth(1);
            }
        }
    }
}

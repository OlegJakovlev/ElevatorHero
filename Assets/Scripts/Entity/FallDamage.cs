using Entity.Health;
using Entity.Health.PlayerHealth;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(PlayerHealth))]
    public class FallDamage : MonoBehaviour
    {
        [SerializeField] private float _maxVerticalVelocity = 7f;
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

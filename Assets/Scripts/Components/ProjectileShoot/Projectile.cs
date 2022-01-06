using Components.Health;
using UnityEngine;

namespace Components.ProjectileShoot
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Vector2 _deltaVelocity;
        private Rigidbody2D _rigidbody;
        [SerializeField] private LayerMask _collisionMask;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_collisionMask.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                if (other.gameObject.TryGetComponent(out EntityHealth health))
                {
                    health.LoseHealth(1);
                }
                
                gameObject.SetActive(false);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition((Vector2) transform.position + _deltaVelocity);
        }

        public void ChangeProjectileDirection(float direction)
        {
            _deltaVelocity.x = Mathf.Abs(_deltaVelocity.x) * direction;
        }

        public void SetLayerMask(LayerMask newMask)
        {
            _collisionMask = newMask;
        }
    }
}

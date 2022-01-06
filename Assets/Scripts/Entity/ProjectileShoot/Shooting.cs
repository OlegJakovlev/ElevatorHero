using UnityEngine;

namespace Entity.ProjectileShoot
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private LayerMask _noSpawnMask;
        [SerializeField] private LayerMask _projectileMask;
        
        [Header("Shooting Point")]
        [SerializeField] private Transform _shootingPivot;
        private Vector3 _finalShootingPivot;

        [Header("Shooting Times")]
        [SerializeField] private float _timeDelayBetweenShots = 1.0f;
        private float _lastTimeShootTime = 0.0f;

        [Header("Object Pool")]
        [SerializeField] private ObjectPool.ObjectPool _projectileObjectPool;

        private void Update()
        {
            _lastTimeShootTime += Time.deltaTime;
        }

        public void SetProjectilePool(ObjectPool.ObjectPool newPool)
        {
            _projectileObjectPool = newPool;
        }
        
        public void ShootEvent(float direction)
        {
            if (_lastTimeShootTime < _timeDelayBetweenShots) return;

            // Pivot calculation
            _finalShootingPivot = _shootingPivot.localPosition;
            _finalShootingPivot.x *= (direction == 0 ? 1 : direction);

            // Check if projectile position is empty space
            Vector2 worldProjectilePosition = gameObject.transform.position + _finalShootingPivot;
            
            Collider2D tmp = Physics2D.OverlapBox(worldProjectilePosition, new Vector2(0.2f, 0.2f), 0f, _noSpawnMask);
            if (tmp != null) return;
            
            // Get projectile from object pool
            GameObject projectile = _projectileObjectPool.GetPooledObject();
            if (!projectile) return;
            
            // Shooting direction
            projectile.GetComponent<Projectile>().ChangeProjectileDirection(direction == 0 ? 1 : direction);
            projectile.GetComponent<Projectile>().SetLayerMask(_projectileMask);
            
            // Move projectile to pivot and shift by direction
            projectile.transform.position = worldProjectilePosition;
            projectile.SetActive(true);

            // Reset timer
            _lastTimeShootTime = 0;
        }
    }
}

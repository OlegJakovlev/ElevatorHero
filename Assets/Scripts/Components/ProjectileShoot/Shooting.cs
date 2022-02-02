using System;
using Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components.ProjectileShoot
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private int _newProjectileLayer;
        [SerializeField] private LayerMask _noSpawnMask;
        [SerializeField] private LayerMask _projectileMask;
        
        [Header("Shooting Point")]
        [SerializeField] private Transform _shootingPivot;
        private Vector3 _finalShootingPivot;

        [Header("Shooting Times")]
        [SerializeField] private float _timeDelayBetweenShots = 1.0f;
        private float _lastTimeShootTime;

        [Header("Object Pool")]
        [SerializeField] private ObjectPool.ObjectPool _projectileObjectPool;

        private void OnEnable()
        {
            _lastTimeShootTime = _timeDelayBetweenShots;
        }

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
            _finalShootingPivot.x *= direction == 0 ? -1 : direction;

            // Check if projectile position is empty space
            Vector2 worldProjectilePosition = gameObject.transform.position + _finalShootingPivot;
            
            // Get projectile from object pool
            GameObject projectile = _projectileObjectPool.GetPooledObject();
            if (!projectile) return;
            
            // Check if projectile spawns inside another object
            Vector3 projectileDimensions = projectile.transform.localScale;
            
            Collider2D tmp = Physics2D.OverlapBox(
                worldProjectilePosition,
                new Vector2(projectileDimensions.x, projectileDimensions.y),
                0f,
                _noSpawnMask
            );
            
            if (tmp != null) return;

            // Set Shooting direction, collision layer mask and layer of object itself
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.ChangeProjectileDirection(direction == 0 ? 1 : direction);
            projectileComponent.SetLayerMask(_projectileMask);
            projectileComponent.SetLayer(_newProjectileLayer);

            // Play sound
            AudioSetup.Instance.PlaySound(Random.Range(1, 5) == 4 ? "Shoot1" : "Shoot2");
            
            // Move projectile to pivot and shift by direction
            projectile.transform.position = worldProjectilePosition;
            projectile.SetActive(true);

            // Reset timer
            _lastTimeShootTime = 0;
        }
    }
}

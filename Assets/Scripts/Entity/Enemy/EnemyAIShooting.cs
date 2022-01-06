using System;
using System.Timers;
using Components.ProjectileShoot;
using UnityEngine;

namespace Entity.Enemy
{
    public class EnemyAIShooting : MonoBehaviour
    {
        [SerializeField] private Shooting _shooting;
        [SerializeField] private LayerMask _mask;
        
        private bool _playerInRange;
        private float _shootingDirection;

        private void Update()
        {
            if (_playerInRange) _shooting.ShootEvent(_shootingDirection);
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _playerInRange = true;
                _shootingDirection = (other.gameObject.transform.position.x > gameObject.transform.position.x) ? 1 : -1;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _playerInRange = false;
            }
        }
    }
}

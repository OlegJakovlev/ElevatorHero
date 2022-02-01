using Components.Health;
using Components.Health.PlayerHealth;
using UnityEngine;

namespace Components
{
    public class DeathTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _tolerance = 0.2f;
        private float _currentTime;
    
        private void OnTriggerStay2D(Collider2D entryCollider)
        {
            if ((_layerMask.value & (1 << entryCollider.gameObject.layer)) > 0)
            {
                _currentTime += Time.deltaTime;
                if (_tolerance > _currentTime) return;
                
                if (entryCollider.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.LoseHealth(1);
                    return;
                }
            
                if (entryCollider.TryGetComponent(out EntityHealth enemyHealth))
                {
                    enemyHealth.LoseHealth(1);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D entryCollider)
        {
            _currentTime = 0;
        }
    }
}

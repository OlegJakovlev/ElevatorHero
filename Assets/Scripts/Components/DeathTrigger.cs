using Components.Health;
using Components.Health.PlayerHealth;
using UnityEngine;

namespace Components
{
    public class DeathTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
    
        private void OnTriggerEnter2D(Collider2D entryCollider)
        {
            if ((_layerMask.value & (1 << entryCollider.gameObject.layer)) > 0)
            {
                if (entryCollider.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.LoseHealth(1);
                    return;
                }
            
                if (entryCollider.TryGetComponent(out EntityHealth enemyHealth))
                {
                    enemyHealth.LoseHealth(1);
                    return;
                }
            }
        }
    }
}

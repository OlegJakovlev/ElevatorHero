using System.Collections.Generic;
using Components;
using UnityEngine;

namespace Entity.Player
{
    using Elevator;
    
    public class ItemActivator : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        private List<IActivator> _currentActivationItemsInRange;
        private Elevator _currentElevator;
        
        private void Awake()
        {
            _currentActivationItemsInRange = new List<IActivator>();
        }

        public void Activate()
        {
            foreach (var item in _currentActivationItemsInRange)
            {
                item.Activate();
            }
        }

        public void CallElevator(float direction)
        {
            if (_currentElevator == null || direction == 0) return;

            if (direction > 0)
            {
                _currentElevator.CallUp();
            }
            else if (direction < 0)
            {
                _currentElevator.CallDown();
            }
        }

        private void OnTriggerEnter2D(Collider2D newCollider)
        {
            if ((_mask.value & (1 << newCollider.gameObject.layer)) <= 0) return;

            if (newCollider.gameObject.TryGetComponent(out Elevator elevator))
            {
                _currentElevator = elevator;
            }
            
            if (newCollider.gameObject.TryGetComponent(out IActivator activator))
            {
                // Add items only once
                if (!_currentActivationItemsInRange.Contains(activator)) _currentActivationItemsInRange.Add(activator);
            }
        }

        private void OnTriggerExit2D(Collider2D newCollider)
        {
            if (newCollider.gameObject.TryGetComponent(out Elevator _))
            {
                _currentElevator = null;
            }
            
            if (newCollider.gameObject.TryGetComponent(out IActivator activator))
            {
                _currentActivationItemsInRange.Remove(activator);
            }
        }
    }
}

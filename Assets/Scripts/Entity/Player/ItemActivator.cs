using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Player
{
    public class ItemActivator : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        private List<IActivator> _currentActivationItemsInRange;

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

        private void OnTriggerEnter2D(Collider2D newCollider)
        {
            if ((_mask.value & (1 << newCollider.gameObject.layer)) <= 0) return;
            
            if (newCollider.gameObject.TryGetComponent(out IActivator activator))
            {
                _currentActivationItemsInRange.Add(activator);
            }
        }

        private void OnTriggerExit2D(Collider2D newCollider)
        {
            if (newCollider.gameObject.TryGetComponent(out IActivator activator))
            {
                _currentActivationItemsInRange.Remove(activator);
            }
        }
    }
}

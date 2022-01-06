using System;
using UnityEngine;

namespace Entity.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatIsGround;
        
        public event Action ValueChanged; 
        public bool IsGrounded { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_whatIsGround.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsGrounded = true;
            ValueChanged?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_whatIsGround.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsGrounded = false;
            ValueChanged?.Invoke();
        }
    }
}

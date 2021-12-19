using System;
using UnityEngine;

namespace Entity.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatIsGround;
        
        public Action valueChanged; 
        public bool IsGrounded { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_whatIsGround.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsGrounded = true;
            valueChanged?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_whatIsGround.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsGrounded = false;
            valueChanged?.Invoke();
        }
    }
}

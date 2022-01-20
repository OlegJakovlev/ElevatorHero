using System;
using UnityEngine;

namespace Entity.Player
{
    public class WallChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatIsWall;

        public event Action ValueChanged; 
        public bool IsOnWall { get; private set; }

        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_whatIsWall.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsOnWall = true;
            ValueChanged?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_whatIsWall.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            IsOnWall = false;
            ValueChanged?.Invoke();
        }
    }
}
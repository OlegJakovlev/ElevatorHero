using UnityEngine;

namespace Entity.Escalator
{
    public class EscalatorUseButton : MonoBehaviour, IActivator
    {
        [SerializeField] private LayerMask _mask;
        
        [SerializeField] private Escalator _escalator;
        [SerializeField] private Transform _end;

        private GameObject _player;
        
        public void Activate()
        {
            _escalator.Use(_player.transform, _end);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _player = other.gameObject;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _player = null;
            }
        }
    }
}
using Components;
using Score;
using UnityEngine;

namespace Entity.Door
{
    public class DoorActivator : MonoBehaviour, IActivator
    {
        [SerializeField] private Door _door;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private LayerMask _unsafeMask;
        private GameObject _player;
        
        [SerializeField] private ScoreSetup _score;
        
        private void Awake()
        {
            if (!_score)
            {
                // Get global controller
                GameObject globalController = GameObject.FindWithTag("GameController");

                if (globalController.TryGetComponent(out ScoreSetup score))
                {
                    _score = score;
                }
            }
        }
        
        public void Activate()
        {
            _score.PlayerOpenDoor();
            _door.Use(_player);
            gameObject.SetActive(false);
        }

        public Door GetDoor()
        {
            return _door;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_playerMask.value & (1 << other.gameObject.layer)) > 0)
            {
                _player = other.gameObject;
            }
            
            if ((_unsafeMask.value & (1 << other.gameObject.layer)) > 0)
            {
                _door.IsSafe = false;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_playerMask.value & (1 << other.gameObject.layer)) > 0)
            {
                _player = null;
            }
            
            if ((_unsafeMask.value & (1 << other.gameObject.layer)) > 0)
            {
                _door.IsSafe = true;
            }
        }
    }
}
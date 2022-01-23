using Audio;
using Components;
using Components.Score;
using UnityEngine;

namespace Entity.Door
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorActivator : MonoBehaviour, IActivator
    {
        
        [SerializeField] private Door _door;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private LayerMask _unsafeMask;
        private GameObject _player;
        private bool _active = true;
        
        [Header("Score Trigger")]
        [SerializeField] private ScoreSetup _score;
        [SerializeField] private Collider2D _entryTrigger;

        [Header("Visuals")]
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Sprite _spriteToReplaceFor;
        
        private void Awake()
        {
            _entryTrigger = GetComponent<Collider2D>();
            
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
            if (!_active) return;

            // Disable entry trigger
            _active = false;
            
            _score.PlayerOpenDoor();
            _door.Use(_player);
            
            // Play sound
            AudioSetup.Instance.PlaySound("DoorSound");

            // Replace sprite permanently
            _renderer.sprite = _spriteToReplaceFor;
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
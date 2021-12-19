using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Entity.Elevator
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Elevator : MonoBehaviour
    {
        private readonly Random _rng = new Random();
        private Rigidbody2D _rigidbody;
        [SerializeField] private LayerMask _mask;

        [Header("Type")] 
        [SerializeField] private bool _isVertical;
        
        [Header("Stop Points")]
        [SerializeField] private List<Point> _stops;
        private Point _nextStop;
        private bool _manualCalled = false;
        
        [SerializeField] private float _delayToStayOnStop;
        private float _currentDelayTimer;

        [Header("Controls")]
        [SerializeField] private float _maxDifference;
        private bool _playerInside;
        
        [SerializeField] private float _terminalVelocity;
        private float _velocity;
        private Vector3 _direction;

        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _velocity = 0;
                _playerInside = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
                _currentDelayTimer = 0;
                _playerInside = false;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            ChooseRandomNextStop();
            _velocity = _terminalVelocity;
        }
        
        private void Update()
        {
            if (_playerInside) return;
            
            if (Vector3.Distance(_nextStop.GetPosition(), transform.position) <= _maxDifference)
            {
                _velocity = 0;
                _currentDelayTimer += Time.deltaTime;
                
                if (!_manualCalled)
                {
                    if (_currentDelayTimer > _delayToStayOnStop)
                    {
                        ChooseRandomNextStop();
                    }
                }
                else
                {
                    //
                }
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition((transform.position + _direction * _velocity * Time.deltaTime));
            //_rigidbody.MovePosition((transform.position + (_nextStop.GetPosition() - transform.position) * Time.deltaTime));
        }

        private void ChooseRandomNextStop()
        {
            _currentDelayTimer = 0;
            _velocity = _terminalVelocity;

            // Get new random stop
            Point newStop = null;
            while (newStop == null || _nextStop == newStop)
            {
                newStop = _stops[_rng.Next(0, _stops.Count)];
            }
            _nextStop = newStop;
            
            UpdateMoveDirection();
        }

        public void SetNextStop(Point newStop)
        {
            _currentDelayTimer = 0;
            _velocity = _terminalVelocity;
            
            _nextStop = newStop;
            _manualCalled = true;
            
            UpdateMoveDirection();
        }
        
        private void UpdateMoveDirection()
        {
            if (_isVertical)
            {
                _direction = new Vector2(
                    0,
                    _nextStop.GetPosition().y >= transform.position.y ? 1 : -1
                );
            }
            else
            {
                _direction = new Vector2(
                    _nextStop.GetPosition().x >= transform.position.x ? 1 : -1,
                    0
                );
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Entity.Elevator
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Elevator : MonoBehaviour
    {
        [Header("Type")]
        [SerializeField] private bool _isVertical;
        
        [Header("Stop Points")]
        [SerializeField] private List<Point> _stops;
        private int _currentStopIndex;
        private Point _nextStop;
        private readonly Random _rng = new Random();
        
        [Header("Stop Timers")]
        [SerializeField] private float _delayToStayOnStop;
        private float _currentDelayTimer;

        [Header("Controls")]
        [SerializeField] private float _maxDifference;
        private bool _playerInside;
        
        [Header("Movement Physics")]
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _terminalVelocity;
        private Rigidbody2D _rigidbody;
        private float _velocity;
        private Vector3 _direction;
        private bool _manualCalled;

        [Header("Level Alarm")]
        [SerializeField] private float _delayTime;
        private LevelTimer _levelTimer;
        private bool _alarmed;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_mask.value & (1 << other.gameObject.layer)) > 0)
            {
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
            
            // Simulate elevator delay on each level alarm

            // Get level controller
            GameObject levelController = GameObject.FindWithTag("LevelManager");

            if (levelController.TryGetComponent(out LevelTimer timer))
            {
                _levelTimer = timer;
                _levelTimer.OnAlarm += () => _alarmed = true;
            }
            
            if (!_levelTimer) Debug.LogWarning("No level timer assigned!");
        }

        private void Start()
        {
            ChooseRandomNextStop();
            _velocity = _terminalVelocity;
        }
        
        private void Update()
        {
            // Check if we are on correct stop
            if (Vector3.Distance(_nextStop.GetPosition(), transform.position) <= _maxDifference)
            {
                // Stop here
                _velocity = 0;
                
                // Dont move while player is inside
                if (!_playerInside) _currentDelayTimer += Time.deltaTime;

                if (_currentDelayTimer > _delayToStayOnStop)
                {
                    // Player left the elevator
                    if (!_playerInside)
                    {
                        _manualCalled = false;
                    }
                    
                    // Choose next random stop
                    if (!_manualCalled)
                    {
                        ChooseRandomNextStop();
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition((transform.position + _direction * (_velocity * Time.deltaTime))); // TODO: LERP of speed-to-distance_left ratio 
            //_rigidbody.MovePosition((transform.position + (_nextStop.GetPosition() - transform.position) * Time.deltaTime));
        }

        private void ChooseRandomNextStop()
        {
            ResetTimerAndVelocity();

            // Get new random stop
            Point newStop = null;
            while (newStop == null || _nextStop == newStop)
            {
                _currentStopIndex = _rng.Next(0, _stops.Count);
                newStop = _stops[_currentStopIndex];
            }
            _nextStop = newStop;
            
            UpdateMoveDirection();
        }

        public void SetNextStop(Point newStop)
        {
            StartCoroutine(SetNextStopWithDelay(newStop));
        }

        private IEnumerator SetNextStopWithDelay(Point newStop)
        {
            // Simulate unavailable behaviour
            if (_alarmed)
            {
                yield return new WaitForSeconds(_delayTime);
                _alarmed = false;
            }

            _manualCalled = true;
            _currentStopIndex = _stops.FindIndex(stop => stop.GetPosition() == newStop.GetPosition());
            _nextStop = newStop;

            UpdateMoveDirection();
            ResetTimerAndVelocity();
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

        private void ResetTimerAndVelocity()
        {
            _currentDelayTimer = 0;
            _velocity = _terminalVelocity;
        }

        public void CallUp()
        {
            if (_currentStopIndex < _stops.Count - 1)
            {
                SetNextStop(_stops[++_currentStopIndex]);
            }
        }

        public void CallDown()
        {
            if (_currentStopIndex > 0)
            {
                SetNextStop(_stops[--_currentStopIndex]);
            }
        }
    }
}

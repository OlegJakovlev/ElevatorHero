using UnityEngine;

namespace Entity.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(JumpType))]
    public class PhysicsMovement : MonoBehaviour
    {
        [Header("Ground")]
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private float _initialGroundDelayTime = 0.2f;
        private float _currentGroundDelayTime; // Used for jump in air
        private float _lastTimeGrounded;
        private bool _isGrounded;

        [Header("Walls")] 
        [SerializeField] private WallChecker _wallChecker;
        private bool _isWalled;

        [Header("Jump")]
        [SerializeField] private JumpType _jumpAnimation;
        [SerializeField] private float _initialJumpDelayTime = 0.4f;
        [SerializeField] private float _jumpCheckDelay = 0.125f;
        private float _currentJumpDelayTime;

        [Header("Speed")]
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _airResistanceCoefficient = 0.7f;

        private Rigidbody2D _rigidbody;
        private bool _playAnimation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _jumpAnimation = GetComponent<JumpType>();
        }
        
        private void OnEnable()
        {
            _groundChecker.ValueChanged += UpdateGroundedStatus;
            _wallChecker.ValueChanged += UpdateWallStatus;
        }

        private void OnDisable()
        {
            _groundChecker.ValueChanged -= UpdateGroundedStatus;
            _wallChecker.ValueChanged -= UpdateWallStatus;
        }

        private void UpdateGroundedStatus()
        {
            _isGrounded = _groundChecker.IsGrounded;
        }
        
        private void UpdateWallStatus()
        {
            _isWalled = _wallChecker.IsOnWall;
        }

        private void Update()
        {
            // Timers
            _currentJumpDelayTime -= Time.deltaTime;
            _currentGroundDelayTime -= Time.deltaTime;
            _lastTimeGrounded += Time.deltaTime;

            if (_isGrounded)
            {
                _lastTimeGrounded = 0;
                _currentGroundDelayTime = _initialGroundDelayTime;
            }
            
            // Apply jump animation
            if (_playAnimation)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpAnimation.GetProgressValue() * _jumpAnimation._heightCoefficient);

                if (_jumpAnimation.GetProgress() > 1f)
                {
                    _playAnimation = false;
                }
            }
        }

        public void ApplyHorizontal(float direction)
        {
            if (_isGrounded)
            {
                _rigidbody.velocity = new Vector2 (
                    Mathf.Lerp(_rigidbody.velocity.x, direction * _speed, -1 * _currentJumpDelayTime),
                    _rigidbody.velocity.y
                );
            }
            
            // In air make linear interpolation of speed
            else
            {
                _rigidbody.velocity = new Vector2 (
                    Mathf.Lerp(_rigidbody.velocity.x, direction * _speed * _airResistanceCoefficient, _lastTimeGrounded),
                    _rigidbody.velocity.y
                );
            }

            if (_isWalled)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -1 * _lastTimeGrounded * _jumpAnimation._heightCoefficient);
            }
        }

        public void ApplyVertical(float direction)
        {
            if (direction == 1f) _currentJumpDelayTime = _initialJumpDelayTime;
            
            // Check if we run animation of jump
            if (_playAnimation) return;
            
            if (_currentJumpDelayTime < _jumpCheckDelay || _currentGroundDelayTime < 0) return;

            // Reset timers
            _currentGroundDelayTime = 0;
            _currentJumpDelayTime = 0;

            // Call Jump
            _jumpAnimation.ResetProgress();
            _playAnimation = true;
        }
    }
}

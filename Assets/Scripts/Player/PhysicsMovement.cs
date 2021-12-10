using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private JumpType _jump;

    [Header("Ground Time")]
    [SerializeField] private float _initialGroundTime = 0.2f;
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    [Header("Speed")]
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _speedInAirCooeficient = 0.7f;

    private float _groundTime;
    private bool _isGrounded;
    private float _lastTimeGrounded;
    private Rigidbody2D _rigidbody;

    public Action Jump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _lastTimeGrounded += Time.deltaTime;
        _groundTime -= Time.deltaTime;

        // Bug: It is possible to jump after initial jump
        if (_lastTimeGrounded > 0.125f)
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);

        if (_isGrounded)
        {
            _lastTimeGrounded = 0;
            _groundTime = _initialGroundTime;
        }
    }

    public void ApplyHorizontal(float direction)
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
        }
        else
        {
            // Timer for time in air and linear decreasing speed
            _rigidbody.velocity = new Vector2 (
                Mathf.Lerp(_rigidbody.velocity.x, _rigidbody.velocity.x * _speedInAirCooeficient, _lastTimeGrounded),
                _rigidbody.velocity.y
            );
        }
    }

    public void ApplyVertical()
    {
        if (_groundTime < 0) return;

        _isGrounded = false;

        // Reset timers
        _groundTime = 0;
        Jump?.Invoke();

        // Apply jump
        _rigidbody.velocity = Vector2.up * _jump.gravityRise.Evaluate(1 - _lastTimeGrounded) * _jump.initalJumpForce;
        //_rigidbody.velocity = Vector2.up * _jumpHeight;
    }
}

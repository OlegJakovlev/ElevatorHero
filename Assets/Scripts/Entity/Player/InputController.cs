using Components.ProjectileShoot;
using UnityEngine;

namespace Entity.Player
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(Shooting))]
    [RequireComponent(typeof(ItemActivator))]
    [RequireComponent(typeof(SpriteFlipper))]
    [RequireComponent(typeof(Animator))]
    public class InputController : MonoBehaviour
    {
        // Input actions mapping
        private InputMapping _controls;

        [Header("Physics")]
        [SerializeField] private GroundChecker _groundChecker;
        private Vector2 _movementVector;
        private Vector2 _lastNonZeroMovementVector = Vector2.left;
        private PhysicsMovement _physicsMovement;

        [Header("Shooting")] 
        private Shooting _shooting;

        [Header("Item Activator")]
        private ItemActivator _itemActivator;

        [Header("Visuals")]
        private Animator _animator;
        private SpriteFlipper _spriteFlipper;

        private void Awake()
        {
            _controls = new InputMapping();
            _physicsMovement = GetComponent<PhysicsMovement>();
            _shooting = GetComponent<Shooting>();
            _itemActivator = GetComponent<ItemActivator>();
            _spriteFlipper = GetComponent<SpriteFlipper>();
            _animator = GetComponent<Animator>();

            // Player Movement
            _controls.Character.Shoot.performed += _ => Shoot();
            _controls.Character.Movement.performed += context => Move(context.ReadValue<float>());
            _controls.Character.Jump.performed += context => Jump(context.ReadValue<float>());
            _controls.Character.Duck.performed += context => Duck(context.ReadValue<float>());
            _controls.Character.Activation.performed += _ => Activate();
            
            // Pause menu action
            _controls.UI.Pause.performed += _ =>
            {
                CustomSceneManager.Instance.SetPauseMenuActive(true);
                OnDisable();
            };

            // Elevator
            _controls.Character.ElevatorVerticalControl.performed +=
                context => _itemActivator.CallVerticalElevator(context.ReadValue<float>());
            
            _controls.Character.ElevatorHorizontalControl.performed +=
                context => _itemActivator.CallHorizontalElevator(context.ReadValue<float>());
        }

        public void OnEnable()
        {
            ResetControls();
            _controls.Enable();
        }

        private void OnDisable()
        {
            ResetControls();
            _controls.Disable();
        }

        private void Update()
        {
            if (_movementVector == Vector2.zero
                && !_animator.IsInTransition(0)
                && _animator.GetCurrentAnimatorStateInfo(0).length > 1)
            {
                _animator.Play("PlayerIdle");
            }

            _physicsMovement.ApplyHorizontal(_movementVector.x);
            _physicsMovement.ApplyVertical(_movementVector.y);
        }

        private void ResetControls()
        {
            // Reset movement vectors
            _movementVector = Vector2.zero;
            _lastNonZeroMovementVector = Vector2.left;
            
            // Release state of controls
            _controls.Character.Shoot.Dispose();
            _controls.Character.Movement.Dispose();
            _controls.Character.Jump.Dispose();
            _controls.Character.Duck.Dispose();
            _controls.Character.Activation.Dispose();
        }

        private void Shoot()
        {
            _animator.Play("PlayerShoot");
            _shooting.ShootEvent(_lastNonZeroMovementVector.x);
        }
        
        private void Move(float direction)
        {
            _movementVector.x = direction;

            if (direction != 0)
            {
                _lastNonZeroMovementVector.x = direction;
                _spriteFlipper.FlipSprite(direction > 0);
                if (_groundChecker.IsGrounded) _animator.Play("PlayerRun");
            }
        }
        
        private void Jump(float direction)
        {
            _movementVector.y = direction;
            if (direction != 0)
            {
                _lastNonZeroMovementVector.y = direction;
                _animator.Play("PlayerJump");
            }
        }

        private void Duck(float value)
        {
            _animator.Play("PlayerDuck");
        }

        private void Activate()
        {
            _itemActivator.Activate();
        }
    }
}

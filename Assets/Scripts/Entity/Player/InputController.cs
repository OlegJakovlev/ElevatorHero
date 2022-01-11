using Components.ProjectileShoot;
using UnityEngine;

namespace Entity.Player
{
    [RequireComponent(typeof(PhysicsMovement))]
    [RequireComponent(typeof(Shooting))]
    [RequireComponent(typeof(ItemActivator))]
    public class InputController : MonoBehaviour
    {
        // Input actions mapping
        private InputMapping _controls;

        [Header("Physics")]
        private Vector2 _movementVector;
        private Vector2 _lastNonZeroMovementVector = Vector2.right;
        private PhysicsMovement _physicsMovement;

        [Header("Shooting")] 
        private Shooting _shooting;

        [Header("Item Activator")]
        private ItemActivator _itemActivator;

        private void Awake()
        {
            _controls = new InputMapping();
            _physicsMovement = GetComponent<PhysicsMovement>();
            _shooting = GetComponent<Shooting>();
            _itemActivator = GetComponent<ItemActivator>();
            
            _controls.Character.Shoot.performed += _ => _shooting.ShootEvent(_lastNonZeroMovementVector.x);
            _controls.Character.Movement.performed += context => Move(context.ReadValue<float>());
            _controls.Character.Jump.performed += context => Jump(context.ReadValue<float>());
            _controls.Character.Duck.performed += context => Duck(context.ReadValue<float>());
            _controls.Character.Activation.performed += _ => Activate();
        }

        private void OnEnable()
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
            _physicsMovement.ApplyHorizontal(_movementVector.x);
            _physicsMovement.ApplyVertical(_movementVector.y);
        }

        private void ResetControls()
        {
            // Reset movement vectors
            _movementVector = Vector2.zero;
            _lastNonZeroMovementVector = Vector2.right;
            
            // Release state of controls
            _controls.Character.Shoot.Dispose();
            _controls.Character.Movement.Dispose();
            _controls.Character.Jump.Dispose();
            _controls.Character.Duck.Dispose();
            _controls.Character.Activation.Dispose();
        }

        private void Move(float direction)
        {
            _movementVector.x = direction;
            if (direction != 0) _lastNonZeroMovementVector.x = direction;
        }
        
        private void Jump(float direction)
        {
            // Try to use elevator
            _itemActivator.CallElevator(direction);
            
            _movementVector.y = direction;
            if (direction != 0) _lastNonZeroMovementVector.y = direction;
        }

        private void Duck(float pressed)
        {
            _physicsMovement.Duck(pressed);
        }

        private void Activate()
        {
            _itemActivator.Activate();
        }
    }
}

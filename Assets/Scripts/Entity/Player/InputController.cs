using Entity.ProjectileShoot;
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
            
            _controls.Character.Shoot.performed += context => _shooting.ShootEvent(_lastNonZeroMovementVector.x);
            _controls.Character.Movement.performed += context => Move(context.ReadValue<float>());
            _controls.Character.Jump.performed += context => Jump(context.ReadValue<float>());
            _controls.Character.Duck.performed += context => Duck(context.ReadValue<float>());
            _controls.Character.Activation.performed += context => Activate();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Update()
        {
            _physicsMovement.ApplyHorizontal(_movementVector.x);
            _physicsMovement.ApplyVertical(_movementVector.y);
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
            Vector3 currentScale = transform.localScale;
            if (pressed >= 1)
            {
                transform.localScale = new Vector3(currentScale.x, currentScale.y * 0.75f, currentScale.z);
            }
            else
            {
                transform.Translate(new Vector3(0, 1 - 0.75f, 0));
                transform.localScale = new Vector3(currentScale.x, currentScale.y * (1 / 0.75f), currentScale.z);
            }
        }

        private void Activate()
        {
            _itemActivator.Activate();
        }
    }
}

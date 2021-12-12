using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class InputController : MonoBehaviour
    {
        // Input actions mapping
        private InputMapping _controls;
        
        [Header("Physics")]
        private Vector2 _movementVector;
        private PhysicsMovement _physicsMovement;

        private void Awake()
        {
            _controls = new InputMapping();
            _physicsMovement = GetComponent<PhysicsMovement>();
            
            _controls.Character.Shoot.performed += context => Shoot();
            _controls.Character.Movement.performed += context => Move(context.ReadValue<float>());
            _controls.Character.Jump.performed += context => Jump(context.ReadValue<float>());
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
        }
        
        private void Jump(float direction)
        {
            _movementVector.y = direction;
        }

        private void Shoot()
        {
            //print("Shoot!");
        }
    }
}

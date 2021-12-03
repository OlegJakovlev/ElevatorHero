using UnityEngine;

// https://gustavcorpas.medium.com/building-a-customizable-jump-in-unity-using-animation-curves-a168a618428d

[RequireComponent(typeof(PhysicsMovement))]
public class InputController : MonoBehaviour
{
    [SerializeField] private float _initialPressTime = 0.4f;
    private PhysicsMovement _physicsMovement;
    private float _pressTime;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
    }

    private void Update()
    {
        OnMove(Input.GetAxisRaw("Horizontal"));

        // Possibility to press jump in air
        _pressTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W)) _pressTime = _initialPressTime;

        if (_pressTime > 0) OnJump();
    }

    private void OnEnable()
    {
        _physicsMovement.Jump += ResetTimer;
    }

    private void OnDisable()
    {
        _physicsMovement.Jump -= ResetTimer;
    }

    private void ResetTimer()
    {
        _pressTime = 0;
    }

    private void OnMove(float horizontalForce)
    {
        _physicsMovement.ApplyHorizontal(horizontalForce);
    }

    private void OnJump()
    {
        _physicsMovement.ApplyVertical();
    }
}

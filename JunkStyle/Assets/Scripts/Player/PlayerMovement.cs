using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerControls
{
    [SerializeField]
    private float moveSpeed;

    private Vector2 movementInput;

    private void Start()
    {
        input.Player.Movement.started += OnMovementInput;
        input.Player.Movement.performed += OnMovementInput;
        input.Player.Movement.canceled += OnMovementInput;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        GetDirection();
        controller.Move(Time.deltaTime * movement);
    }

    private void GetDirection()
    {
        Vector3 forward = transform.forward * movementInput.y;
        Vector3 right = transform.right * movementInput.x;
        Vector3 direction = (forward + right).normalized * moveSpeed;

        movement = new Vector3(direction.x, movement.y, direction.z);
    }
}

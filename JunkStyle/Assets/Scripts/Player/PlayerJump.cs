using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : PlayerControls
{
    [SerializeField]
    private float jumpHeight, jumpTimeToApex;

    private float jumpVelocity, gravity;
    private bool isJumpPressed;

    private void Start()
    {
        input.Player.Jump.started += OnJump;
        input.Player.Jump.performed += OnJump;
        input.Player.Jump.canceled += OnJump;

        CalculatePhysics();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase.Equals(InputActionPhase.Started))
            isJumpPressed = true;
    }

    //Вычисление скорости прыжка и гравитации для параболической траектории прыжка
    private void CalculatePhysics()
    {
        float time = jumpTimeToApex / 2;
        jumpVelocity = (2 * jumpHeight) / time;
        gravity = -(2 * jumpHeight) / Mathf.Pow(time, 2);
    }

    private void Update()
    {
        HandleGravity();
        HandleJump();
    }

    private void HandleGravity()
    {
        if (controller.isGrounded)
            movement.y = -0.05f;
        else
        {
            //Вычисление среднего значения скорости прыжка для стабильности на разной частоте кадров
            float oldVelocity = movement.y;
            float newVelocity = movement.y + (gravity * Time.deltaTime);
            float nextVelocity = (oldVelocity + newVelocity) / 2;
            movement.y = nextVelocity;
        }
    }

    private void HandleJump()
    {
        if (controller.isGrounded && isJumpPressed)
        {
            isJumpPressed = false;
            movement.y = jumpVelocity / 2;
        }
    }
}

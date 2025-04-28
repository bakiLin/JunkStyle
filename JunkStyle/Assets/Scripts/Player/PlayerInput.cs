using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerJump playerJump;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private TapManager tapManager;

    private KeyboardInput keyboardInput;

    private InputAction jumpAction, moveAction, pressAction, deltaAction;

    public Vector2 direction { get; private set; }

    public Vector2 position { get; private set; }

    public Vector2 delta { get; private set; }

    private void Awake()
    {
        keyboardInput = new KeyboardInput();
    }

    private void OnEnable()
    {
        keyboardInput.Enable();
        
        jumpAction = keyboardInput.Keyboard.Jump;
        moveAction = keyboardInput.Keyboard.Movement;
        pressAction = keyboardInput.Keyboard.Press;
        deltaAction = keyboardInput.Keyboard.Delta;

        jumpAction.started += Jump;
        pressAction.started += Raycast;
    }

    private void OnDisable()
    {
        jumpAction.started -= Jump;
        pressAction.started -= Raycast;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        playerJump.Jump();
    }

    private void Raycast(InputAction.CallbackContext context)
    {
        tapManager.Raycast();
    }

    private void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        delta = deltaAction.ReadValue<Vector2>();
    }
}

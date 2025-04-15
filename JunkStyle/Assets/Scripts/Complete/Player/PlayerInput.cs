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

    private InputAction jumpAction, moveAction, pressAction, positionAction, deltaAction;

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
        positionAction = keyboardInput.Keyboard.Position;
        deltaAction = keyboardInput.Keyboard.Delta;

        jumpAction.started += (InputAction.CallbackContext context) => playerJump.Jump();
        pressAction.started += (InputAction.CallbackContext context) 
            => tapManager.Raycast(positionAction.ReadValue<Vector2>());
    }

    private void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        position = positionAction.ReadValue<Vector2>();
        delta = deltaAction.ReadValue<Vector2>();
    }
}

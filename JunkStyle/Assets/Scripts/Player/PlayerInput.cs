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

    [SerializeField]
    private PauseManager pauseManager;

    private KeyboardInput keyboardInput;

    private InputAction jumpAction, moveAction, pressAction, deltaAction, escAction;

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
        escAction = keyboardInput.Keyboard.Esc;

        jumpAction.started += Jump;
        pressAction.started += Raycast;
        escAction.started += Pause;
    }

    private void OnDisable()
    {
        jumpAction.started -= Jump;
        pressAction.started -= Raycast;
        escAction.started -= Pause;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        playerJump.Jump();
    }

    private void Raycast(InputAction.CallbackContext context)
    {
        tapManager.Raycast();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        pauseManager.Pause();
    }

    private void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        delta = deltaAction.ReadValue<Vector2>();
    }
}

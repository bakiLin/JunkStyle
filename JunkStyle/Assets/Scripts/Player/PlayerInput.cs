using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    [Inject]
    private PlayerJump playerJump;

    [Inject]
    private TapManager tapManager;

    [Inject]
    private PauseManager pauseManager;

    private KeyboardInput keyboardInput;

    public Vector2 direction { get; private set; }

    public Vector2 delta { get; private set; }

    private void Awake()
    {
        keyboardInput = new KeyboardInput();
    }

    private void OnEnable()
    {
        keyboardInput.Enable();

        keyboardInput.Keyboard.Jump.started += Jump;
        keyboardInput.Keyboard.Press.started += Raycast;
        keyboardInput.Keyboard.Esc.started += Pause;
    }

    private void OnDisable()
    {
        keyboardInput.Keyboard.Jump.started -= Jump;
        keyboardInput.Keyboard.Press.started -= Raycast;
        keyboardInput.Keyboard.Esc.started -= Pause;
    }

    private void Update()
    {
        direction = keyboardInput.Keyboard.Movement.ReadValue<Vector2>();
        delta = keyboardInput.Keyboard.Delta.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context) => playerJump.Jump();

    private void Raycast(InputAction.CallbackContext context) => tapManager.Raycast();

    private void Pause(InputAction.CallbackContext context) => pauseManager.Pause();
}

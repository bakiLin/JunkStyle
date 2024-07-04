using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform pivot;

    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField]
    private float yDegreeLimit;

    private PlayerInput input;

    private void Awake() => input = new PlayerInput();

    private void Start()
    {
        input.Player.Rotation.performed += OnRotate;
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        Vector2 mouseInput = context.ReadValue<Vector2>();

        RotationX(mouseInput.x);
        RotationY(mouseInput.y);
    }

    private void RotationX(float inputX)
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += inputX * sensitivity.x * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void RotationY(float inputY)
    {
        Vector3 rotation = pivot.rotation.eulerAngles;
        rotation.x -= inputY * sensitivity.y * Time.deltaTime;

        if (rotation.x < 200f && rotation.x > yDegreeLimit)
            rotation.x = yDegreeLimit;

        if (rotation.x > 200f && rotation.x < 360f - yDegreeLimit)
            rotation.x = 360f - yDegreeLimit;

        pivot.rotation = Quaternion.Euler(rotation);
    }

    private void OnEnable() => input.Player.Enable();

    private void OnDisable() => input.Player.Disable();
}

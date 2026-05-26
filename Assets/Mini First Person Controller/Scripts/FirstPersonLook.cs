using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Vector2 velocity = new Vector2(-90f, 0f);
    private Vector2 frameVelocity;

    public float sensitivity = 2;
    public float smoothing = 1.5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    private void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        var rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
    }

    private void LateUpdate()
    {
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        var rotation = character.rotation * Quaternion.AngleAxis(-velocity.y, Vector3.right);
        var position = Vector3.Lerp(transform.position, character.position + Vector3.up,
                20f * Time.deltaTime);
        transform.SetPositionAndRotation(position, rotation);
    }
}

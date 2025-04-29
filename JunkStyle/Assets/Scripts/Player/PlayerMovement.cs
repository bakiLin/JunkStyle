using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private Transform pivot;

    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = playerInput.direction.x * pivot.right + playerInput.direction.y * pivot.forward;
        velocity *= speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}

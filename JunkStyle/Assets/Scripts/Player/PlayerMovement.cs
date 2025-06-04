using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject]
    private PlayerInput playerInput;

    [SerializeField]
    private float speed;

    private Transform pivot;

    private Rigidbody rb;

    private Vector3 velocity;

    private void Awake()
    {
        pivot = transform.Find("Pivot");
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

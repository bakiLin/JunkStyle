using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;
    private Vector3 movement;
    private MoveWithPlatform moveWithPlatform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveWithPlatform = GetComponent<MoveWithPlatform>();
    }

    private void Update()
    {
        Vector3 forward = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 right = transform.right * Input.GetAxisRaw("Horizontal");

        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.7f) && Input.GetAxisRaw("Vertical") > 0)
            forward = Vector3.zero;

        movement = (forward + right).normalized * speed;
        movement.y = 0f;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.fixedDeltaTime * (movement + moveWithPlatform.GetPlatformSpeed()));
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }
}

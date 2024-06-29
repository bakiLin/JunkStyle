using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    [SerializeField]
    private float groundRayDistance;

    [SerializeField]
    private float jumpForce;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, groundRayDistance))
            isGrounded = true;
        else
            isGrounded = false;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}

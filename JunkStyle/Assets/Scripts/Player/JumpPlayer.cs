using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float groundRayDistance;

    [SerializeField]
    private float jumpForce, gravityScale;

    private Rigidbody rb;
    private bool isGrounded, jump;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update()
    {
        Collider[] colls = Physics.OverlapBox(transform.position + Vector3.down, new Vector3(0.25f, 0.1f, 0.25f), Quaternion.identity, groundLayer);

        if (colls.Length > 0) isGrounded = true;
        else isGrounded = false;

        if (isGrounded && !jump && Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }

        if (!isGrounded)
            rb.AddForce(Vector3.up * Physics.gravity.y * gravityScale, ForceMode.Acceleration);
    }
}

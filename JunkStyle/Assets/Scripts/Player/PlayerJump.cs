using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private PlayerGround playerGround;

    [SerializeField]
    private float jumpForce, gravityScale;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, gravityScale, 0f);
    }

    public void Jump()
    {
        if (playerGround.IsGrounded())
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }
}

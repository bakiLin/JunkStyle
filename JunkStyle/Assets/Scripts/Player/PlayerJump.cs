using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce, gravityScale;

    private PlayerGround playerGround;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerGround = GetComponent<PlayerGround>();

        Physics.gravity = new Vector3(0f, gravityScale, 0f);
    }

    public void Jump()
    {
        if (playerGround.IsGrounded())
        {
            Vector3 velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.velocity = velocity;
        }
    }
}

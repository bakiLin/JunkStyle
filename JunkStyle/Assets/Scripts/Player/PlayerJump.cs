using UnityEngine;
using Zenject;

public class PlayerJump : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

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
        if (playerGround.IsGrounded() && Time.timeScale == 1f)
        {
            audioManager.Play("jump", .15f);
            Vector3 velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.velocity = velocity;
        }
    }
}

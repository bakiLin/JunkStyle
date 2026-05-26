using Cysharp.Threading.Tasks;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _coyoteTime = .2f;
    [SerializeField] private float _delayAfterJump = .2f;
    private Rigidbody _rb;
    private float _coyoteTimeCounter;
    private bool _canJump = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_groundCheck.IsGrounded) _coyoteTimeCounter = _coyoteTime;
        else _coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _coyoteTimeCounter > 0f && _canJump)
            JumpAsync().Forget();
    }

    private async UniTask JumpAsync()
    {
        _canJump = false;
        _rb.AddForce(_jumpForce * 100 * Vector3.up);
        _coyoteTimeCounter = 0f;
        await UniTask.Delay((int)(_delayAfterJump * 1000), cancellationToken: destroyCancellationToken);
        _canJump = true;
    }

    private void Reset()
    {
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }
}

using Cysharp.Threading.Tasks;
using MessagePipe;
using System.Threading;
using UnityEngine;
using VContainer;

public class Jump : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _coyoteTime = .2f;
    [SerializeField] private float _delayAfterJump = .2f;
    [SerializeField] private SoundDataSO _jumpSound;
    private Rigidbody _rb;
    private float _coyoteTimeCounter;
    private CancellationTokenSource _cts = new();
    private IPublisher<PlayerJumpMessage> _playerJump;

    [Inject]
    private void Construct(IPublisher<PlayerJumpMessage> playerJump, 
        ISubscriber<StopPlayerMessage> playerKilled, ISubscriber<ResumePlayerMessage> resumePlayer)
    {
        _playerJump = playerJump;
        _rb = GetComponent<Rigidbody>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => StopJumping()),
            resumePlayer.Subscribe(_ => {
                _cts = new();
                JumpAsync(_cts.Token).Forget();
            })
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        JumpAsync(_cts.Token).Forget();
    }

    private void StopJumping()
    {
        _cts?.Cancel();
    }

    private async UniTask JumpAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_groundCheck.IsGrounded) _coyoteTimeCounter = _coyoteTime;
            else _coyoteTimeCounter -= Time.deltaTime;

            if (Input.GetButtonDown("Jump") && _coyoteTimeCounter > 0f && Time.timeScale == 1f)
            {
                var velocity = _rb.velocity;
                velocity.y = _jumpForce;
                _rb.velocity = velocity;
                _coyoteTimeCounter = 0f;
                _playerJump.Publish(new PlayerJumpMessage(_jumpSound));

                await UniTask.Delay((int)(_delayAfterJump * 1000), 
                    cancellationToken: destroyCancellationToken);
            }

            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }
    }

    private void Reset()
    {
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}

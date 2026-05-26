using Cysharp.Threading.Tasks;
using MessagePipe;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VContainer;

public class FirstPersonMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private PlatformRegular _platform;
    private CancellationTokenSource _cts = new();

    public float speed = 5;
    [Header("Running")] public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public List<System.Func<float>> speedOverrides = new();

    [Inject]
    private void Construct(ISubscriber<PlayerKilledMessage> playerKilled)
    {
        _rb = GetComponent<Rigidbody>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => StopMovement())
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        MovementAsync(_cts.Token).Forget();
    }

    private void StopMovement()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _cts?.Cancel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformRegular platform))
            _platform = platform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformRegular platform))
            _platform = null;
    }

    private async UniTask MovementAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            IsRunning = canRun && Input.GetKey(runningKey);

            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();

            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
            _rb.velocity = transform.rotation * new Vector3(targetVelocity.x, _rb.velocity.y, targetVelocity.y);

            if (_platform != null)
                _rb.position += _platform.Delta;

            await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
        }
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}
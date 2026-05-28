using Cysharp.Threading.Tasks;
using MessagePipe;
using System.Threading;
using UnityEngine;
using VContainer;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Vector2 _rotation;
    private Vector2 _velocity;
    private Vector2 frameVelocity;
    private CancellationTokenSource _cts = new();

    public float sensitivity = 2;
    public float smoothing = 1.5f;

    [Inject]
    private void Construct(ISubscriber<StopPlayerMessage> playerKilled,
        ISubscriber<ResumePlayerMessage> resumePlayer)
    {
        DisposableBag.Create(
            playerKilled.Subscribe(_ => StopRotation()),
            resumePlayer.Subscribe(_ => {
                _cts = new();
                _velocity = _rotation;
                RotateAsync(_cts.Token).Forget();
            })
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        _velocity = _rotation;
        Cursor.lockState = CursorLockMode.Locked;
        RotateAsync(_cts.Token).Forget();
    }

    private void StopRotation()
    {
        _cts?.Cancel();
    }

    private async UniTask RotateAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            var rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            _velocity += frameVelocity;
            _velocity.y = Mathf.Clamp(_velocity.y, -90, 90);
            character.localRotation = Quaternion.AngleAxis(_velocity.x, Vector3.up);

            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }
    }

    private void LateUpdate()
    {
        var rotation = character.rotation * Quaternion.AngleAxis(-_velocity.y, Vector3.right);
        var position = Vector3.Lerp(transform.position, character.position + Vector3.up,
                20f * Time.deltaTime);
        transform.SetPositionAndRotation(position, rotation);
    }

    private void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}

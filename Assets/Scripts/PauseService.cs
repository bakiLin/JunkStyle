using Cysharp.Threading.Tasks;
using MessagePipe;
using System.Threading;
using UnityEngine;
using VContainer;

public class PauseService : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool _isPaused;
    private CancellationTokenSource _cts = new();

    [Inject]
    private void Construct(ISubscriber<ResumePlayerMessage> resumePlayer, 
        ISubscriber<PlayerKilledMessage> playerKilled)
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => _cts?.Cancel()),
            resumePlayer.Subscribe(_ => {
                _cts = new();
                PauseAsync(_cts.Token).Forget();
            })
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        PauseAsync(_cts.Token).Forget();
    }

    private async UniTask PauseAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isPaused = !_isPaused;
                _canvasGroup.alpha = _isPaused ? 1f : 0f;
                Time.timeScale = _isPaused ? 0f : 1f;

                if (_isPaused)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }
    }

    public void Resume()
    {
        _isPaused = false;
        _canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}

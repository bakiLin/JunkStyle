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
    private IPublisher<PauseMessage> _pauseMessage;
    private IPublisher<NextSceneMessage> _nextScene;
    private IPublisher<StopPlayerMessage> _stopPlayer;

    [Inject]
    private void Construct(IPublisher<PauseMessage> pauseMessage,
        ISubscriber<ResumePlayerMessage> resumePlayer, ISubscriber<PlayerKilledMessage> playerKilled,
        IPublisher<NextSceneMessage> nextScene, IPublisher<StopPlayerMessage> stopPlayer)
    {
        _pauseMessage = pauseMessage;
        _nextScene = nextScene;
        _stopPlayer = stopPlayer;
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

                _pauseMessage.Publish(new PauseMessage(_isPaused));
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
        _pauseMessage.Publish(new PauseMessage(_isPaused));
    }

    public void GoToMenu()
    {
        _canvasGroup.alpha = 0f;
        _stopPlayer.Publish(new StopPlayerMessage());
        _nextScene.Publish(new NextSceneMessage(0));
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        _cts?.Cancel();
        _cts?.Dispose();
    }
}

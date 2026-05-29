using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class GameFadingManager : MonoBehaviour
{
    private Image _faderImage;
    private UISettingsSO _settings;
    private IPublisher<RespawnPlayerMessage> _respawnPlayer;
    private IPublisher<ResumePlayerMessage> _resumePlayer;

    [Inject]
    private void Construct(UISettingsSO settings, IPublisher<RespawnPlayerMessage> respawnPlayer, 
        IPublisher<ResumePlayerMessage> resumePlayer, ISubscriber<PlayerKilledMessage> playerKilled,
        ISubscriber<NextSceneMessage> nextScene)
    {
        _settings = settings;
        _respawnPlayer = respawnPlayer;
        _resumePlayer = resumePlayer;
        _faderImage = GetComponent<Image>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => PlayerKilledFade().Forget()),
            nextScene.Subscribe(x => NextSceneFade(x.Index).Forget())
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        StartFade().Forget();
    }

    private async UniTask StartFade()
    {
        await UniTask.Delay(100, cancellationToken: destroyCancellationToken);
        await ImageFader.FadeImage(_faderImage, 0f, _settings.FadeDuration, destroyCancellationToken);
    }

    private async UniTask PlayerKilledFade()
    {
        await ImageFader.FadeImage(_faderImage, 1f, _settings.FadeDuration, destroyCancellationToken);
        _respawnPlayer.Publish(new RespawnPlayerMessage());
        await UniTask.Delay((int)(_settings.FadeDelay * 1000), cancellationToken: destroyCancellationToken);
        _resumePlayer.Publish(new ResumePlayerMessage(true));
        await ImageFader.FadeImage(_faderImage, 0f, _settings.FadeDuration, destroyCancellationToken);
    }

    private async UniTask NextSceneFade(int index)
    {
        var operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        await ImageFader.FadeImage(_faderImage, 1f, _settings.FadeDuration, destroyCancellationToken);
        operation.allowSceneActivation = true;
    }
}

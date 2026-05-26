using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class FadingManagerUI : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = .5f;
    [SerializeField] private float _fadeDelay = .3f;
    private Image _faderImage;
    private IPublisher<RespawnPlayerMessage> _respawnPlayer;
    private IPublisher<ResumePlayerMessage> _resumePlayer;

    [Inject]
    private void Construct(IPublisher<RespawnPlayerMessage> respawnPlayer,
        IPublisher<ResumePlayerMessage> resumePlayer, ISubscriber<PlayerKilledMessage> playerKilled)
    {
        _respawnPlayer = respawnPlayer;
        _resumePlayer = resumePlayer;
        _faderImage = GetComponent<Image>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => PlayerKilledFade().Forget())
        ).AddTo(destroyCancellationToken);
    }

    private async UniTask PlayerKilledFade()
    {
        await ImageFader.FadeImage(_faderImage, 1f, _fadeDuration, destroyCancellationToken);
        _respawnPlayer.Publish(new RespawnPlayerMessage());
        await UniTask.Delay((int)(_fadeDelay * 1000), cancellationToken: destroyCancellationToken);
        _resumePlayer.Publish(new ResumePlayerMessage());
        await ImageFader.FadeImage(_faderImage, 0f, _fadeDuration, destroyCancellationToken);
    }
}

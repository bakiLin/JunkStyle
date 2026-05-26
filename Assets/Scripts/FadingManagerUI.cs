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

    [Inject]
    private void Construct(IPublisher<RespawnPlayerMessage> respawnPlayer, 
        ISubscriber<PlayerKilledMessage> playerKilled)
    {
        _respawnPlayer = respawnPlayer;
        _faderImage = GetComponent<Image>();

        DisposableBag.Create(
            playerKilled.Subscribe(_ => PlayerKilledFade().Forget())
        ).AddTo(destroyCancellationToken);
    }

    private async UniTask PlayerKilledFade()
    {
        await Fade(1f, _fadeDuration);
        _respawnPlayer.Publish(new RespawnPlayerMessage());
        await UniTask.Delay((int)(_fadeDelay * 1000), cancellationToken: destroyCancellationToken);
        await Fade(0f, _fadeDuration);
    }

    private async UniTask Fade(float targetValue, float duration)
    {
        await ImageFader.FadeImage(_faderImage, targetValue, duration, destroyCancellationToken);
    }
}

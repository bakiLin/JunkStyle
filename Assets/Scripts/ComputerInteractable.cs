using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private int _nextLevel;
    [SerializeField] private SoundDataSO _interactSound;
    private ISoundManager _soundManager;
    private IPublisher<NextSceneMessage> _nextScene;
    private IPublisher<StopPlayerMessage> _stopPlayer;
    private bool _isInteracted;
    private Outline _outline;

    [Inject]
    private void Construct(ISoundManager soundManager, IPublisher<NextSceneMessage> nextScene,
        IPublisher<StopPlayerMessage> stopPlayer)
    {
        _soundManager = soundManager;
        _nextScene = nextScene;
        _stopPlayer = stopPlayer;
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        Outline(false);
    }

    public void Interact()
    {
        if (!_isInteracted)
        {
            _isInteracted = true;
            _soundManager.Get().Play(_interactSound, transform.position, 
                destroyCancellationToken).Forget();
            _stopPlayer.Publish(new StopPlayerMessage());
            _nextScene.Publish(new NextSceneMessage(_nextLevel));
        }
    }

    public void Outline(bool state)
    {
        if (_outline.enabled == state) return;
        _outline.enabled = state;
    }
}

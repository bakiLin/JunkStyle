using MessagePipe;
using UnityEngine;
using VContainer;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private int _nextLevel;
    private IPublisher<NextSceneMessage> _nextScene;
    private IPublisher<StopPlayerMessage> _stopPlayer;
    private bool _isInteracted;

    [Inject]
    private void Construct(IPublisher<NextSceneMessage> nextScene,
        IPublisher<StopPlayerMessage> stopPlayer)
    {
        _nextScene = nextScene;
        _stopPlayer = stopPlayer;
    }

    public void Interact()
    {
        if (!_isInteracted)
        {
            _isInteracted = true;
            _stopPlayer.Publish(new StopPlayerMessage());
            _nextScene.Publish(new NextSceneMessage(_nextLevel));
        }
    }
}

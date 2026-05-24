using MessagePipe;
using UnityEngine;
using VContainer;

public class RemoteController : NodeBase, IInteractable
{
    [SerializeField] private NodeBase[] _connectedNodes;
    private Transform _button;
    private MeshRenderer _remoteRenderer;
    private RemoteSettingsSO _settings;
    private IPublisher<RemoteMaterialMessage> _remoteMaterial;

    [Inject]
    private void Construct(RemoteSettingsSO settings, 
        IPublisher<RemoteMaterialMessage> remoteMaterial)
    {
        _settings = settings;
        _remoteMaterial = remoteMaterial;
        _button = transform.GetChild(0);
        _remoteRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Switch(_currentState);
    }

    public void Interact()
    {
        _currentState = !_currentState;
        Switch(_currentState);
    }

    public override void Switch(bool state)
    {
        if (state) _button.localRotation = Quaternion.Euler(_settings.OnRotation);
        else _button.localRotation = Quaternion.Euler(_settings.OffRotation);

        _remoteMaterial.Publish(new RemoteMaterialMessage(_remoteRenderer, _currentState));

        foreach (var node in _connectedNodes)
            node.Switch(_currentState);
    }
}

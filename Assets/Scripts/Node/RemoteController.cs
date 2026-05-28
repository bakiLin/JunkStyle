using MessagePipe;
using UnityEngine;
using VContainer;

public class RemoteController : NodeBase, IInteractable
{
    [SerializeField] private NodeBase[] _connectedNodes;
    private Transform _button;
    private MeshRenderer _remoteRenderer;
    private Outline _outline;
    private RemoteSettingsSO _settings;
    private IPublisher<ChangeMaterialMessage> _changeMaterial;

    [Inject]
    private void Construct(RemoteSettingsSO settings, 
        IPublisher<ChangeMaterialMessage> changeMaterial)
    {
        _settings = settings;
        _changeMaterial = changeMaterial;
        _button = transform.GetChild(0);
        _remoteRenderer = GetComponent<MeshRenderer>();
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        Outline(false);
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

        _changeMaterial.Publish(new ChangeMaterialMessage(
            MaterialType.Remote, _remoteRenderer, state));

        foreach (var node in _connectedNodes)
            node.Switch(state);
    }

    public void Outline(bool state)
    {
        if (_outline.enabled == state) return;
        _outline.enabled = state;
    }
}

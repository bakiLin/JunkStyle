using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class RemoteController : NodeBase, IInteractable
{
    [SerializeField] private SoundDataSO _switchSound;
    [SerializeField] private NodeBase[] _connectedNodes;
    private Transform _button;
    private MeshRenderer _remoteRenderer;
    private Outline _outline;
    private RemoteSettingsSO _settings;
    private ISoundManager _soundManager;
    private IPublisher<ChangeMaterialMessage> _changeMaterial;
    private bool _firstSwitch;

    [Inject]
    private void Construct(RemoteSettingsSO settings, ISoundManager soundManager,
        IPublisher<ChangeMaterialMessage> changeMaterial)
    {
        _settings = settings;
        _soundManager = soundManager;
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

        if (_firstSwitch)
        {
            _soundManager.Get()
                .Play(_switchSound, transform.position, destroyCancellationToken).Forget();
        }

        _firstSwitch = true;
        foreach (var node in _connectedNodes)
            node.Switch(state);
    }

    public void Outline(bool state)
    {
        if (_outline.enabled == state) return;
        _outline.enabled = state;
    }
}

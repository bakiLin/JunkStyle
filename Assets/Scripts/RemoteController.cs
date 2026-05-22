using MessagePipe;
using UnityEngine;
using VContainer;

public class RemoteController : MonoBehaviour
{
    [SerializeField] private bool _currentState;
    [SerializeField] private Transform _button;
    [SerializeField] private int _index;
    private MeshRenderer _renderer;
    private RemoteSettingsSO _settings;
    private IPublisher<SwitchRemoteMessage> _switchRemoteController;

    [Inject]
    private void Construct(RemoteSettingsSO settings, IPublisher<SwitchRemoteMessage> switchRemote)
    {
        _settings = settings;
        _switchRemoteController = switchRemote;
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Switch();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_index.ToString()))
        {
            Interact();
        }
    }

    public void Interact()
    {
        _currentState = !_currentState;
        Switch();
        
    }

    private void Switch()
    {
        if (_currentState) _button.localRotation = Quaternion.Euler(_settings.OnRotation);
        else _button.localRotation = Quaternion.Euler(_settings.OffRotation);

        var materials = _renderer.materials;
        materials[2] = _currentState ? _settings.LightOnMaterial : _settings.LightOffMaterial;
        _renderer.materials = materials;

        _switchRemoteController.Publish(new SwitchRemoteMessage(GetInstanceID(), _currentState));
    }
}

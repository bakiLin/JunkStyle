using MessagePipe;
using UnityEngine;
using VContainer;

public class RemoteController : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private Transform _button;
    [SerializeField] private bool _currentState;
    private MeshRenderer _renderer;
    private RemoteControllerSettingsSO _settings;
    private IPublisher<SwitchRemoteControllerMessage> _switchRemoteController;

    [Inject]
    private void Construct(RemoteControllerSettingsSO settings, IPublisher<SwitchRemoteControllerMessage> switchRemoteController)
    {
        _settings = settings;
        _switchRemoteController = switchRemoteController;
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SwitchRemoteController();
    }

    public void Interact()
    {
        _currentState = !_currentState;
        SwitchRemoteController();
        _switchRemoteController.Publish(new SwitchRemoteControllerMessage(_id, _currentState));
    }

    private void SwitchRemoteController()
    {
        if (_currentState) _button.localRotation = Quaternion.Euler(_settings.OnRotation);
        else _button.localRotation = Quaternion.Euler(_settings.OffRotation);

        var materials = _renderer.materials;
        materials[2] = _currentState
            ? _settings.LightOnMaterial : _settings.LightOffMaterial;
        _renderer.materials = materials;
        //_renderer.materials[2] = _currentState 
        //    ? _settings.LightOnMaterial : _settings.LightOffMaterial;
    }
}

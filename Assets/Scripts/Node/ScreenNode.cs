using MessagePipe;
using UnityEngine;
using VContainer;

public class ScreenNode : NodeBase
{
    [SerializeField] private string _platformName;
    private MeshRenderer _renderer;
    private IPublisher<ChangeMaterialMessage> _changeMaterial;
    private IPublisher<ScreenStateChangedMessage> _screenStateChanged;

    [Inject]
    private void Construct(IPublisher<ChangeMaterialMessage> changeMaterial,
        IPublisher<ScreenStateChangedMessage> screenStateChanged)
    {
        _changeMaterial = changeMaterial;
        _screenStateChanged = screenStateChanged;
        _renderer = GetComponent<MeshRenderer>();
    }

    public override void Switch(bool state)
    {
        _currentState = state;
        _changeMaterial.Publish(new ChangeMaterialMessage(
            MaterialType.Screen, _renderer, _currentState));
        _screenStateChanged.Publish(new ScreenStateChangedMessage(_platformName, _currentState));
    }
}

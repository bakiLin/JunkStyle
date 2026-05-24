using MessagePipe;
using UnityEngine;
using VContainer;

public class ScreenNode : NodeBase
{
    private MeshRenderer _renderer;
    private IPublisher<ScreenMaterialMessage> _screenMaterial;

    [Inject]
    private void Construct(IPublisher<ScreenMaterialMessage> screenMaterial)
    {
        _screenMaterial = screenMaterial;
        _renderer = GetComponent<MeshRenderer>();
    }

    public override void Switch(bool state)
    {
        _currentState = state;
        _screenMaterial.Publish(new ScreenMaterialMessage(_renderer, _currentState));
    }
}

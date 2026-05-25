using MessagePipe;
using UnityEngine;
using VContainer;

public class ScreenNode : NodeBase
{
    private MeshRenderer _renderer;
    private IPublisher<ChangeMaterialMessage> _changeMaterial;

    [Inject]
    private void Construct(IPublisher<ChangeMaterialMessage> changeMaterial)
    {
        _changeMaterial = changeMaterial;
        _renderer = GetComponent<MeshRenderer>();
    }

    public override void Switch(bool state)
    {
        _currentState = state;
        _changeMaterial.Publish(new ChangeMaterialMessage(
            MaterialType.Screen, _renderer, _currentState));
    }
}

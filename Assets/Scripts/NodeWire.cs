using MessagePipe;
using UnityEngine;
using VContainer;

public class NodeWire : NodeBase
{
    private MeshRenderer _renderer;
    private IPublisher<WireMaterialMessage> _wireMaterial;

    [Inject]
    private void Construct(IPublisher<WireMaterialMessage> wireMaterial)
    {
        _wireMaterial = wireMaterial;
        _renderer = GetComponent<MeshRenderer>();
    }

    public override void Switch(bool state)
    {
        _currentState = state;
        _wireMaterial.Publish(new WireMaterialMessage(_renderer, _currentState));
    }
}

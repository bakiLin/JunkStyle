using UnityEngine;

public class WireMaterialMessage : EventMessage
{
    public MeshRenderer Renderer { get; private set; }
    public bool State { get; private set; }

    public WireMaterialMessage(MeshRenderer renderer, bool state)
    {
        Renderer = renderer;
        State = state;
    }
}

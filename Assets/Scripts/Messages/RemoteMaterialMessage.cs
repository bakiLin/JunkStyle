using UnityEngine;

public class RemoteMaterialMessage : EventMessage
{
    public MeshRenderer Renderer { get; private set; }
    public bool State { get; private set; }

    public RemoteMaterialMessage(MeshRenderer renderer, bool state)
    {
        Renderer = renderer;
        State = state;
    }
}

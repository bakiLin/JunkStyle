using UnityEngine;

public enum MaterialType { Remote, Wire, Screen }

public class ChangeMaterialMessage : EventMessage
{
    public MaterialType Type { get; private set; }
    public MeshRenderer Renderer { get; private set; }
    public bool State { get; private set; }

    public ChangeMaterialMessage(MaterialType type, MeshRenderer renderer, bool state)
    {
        Type = type;
        Renderer = renderer;
        State = state;
    }
}

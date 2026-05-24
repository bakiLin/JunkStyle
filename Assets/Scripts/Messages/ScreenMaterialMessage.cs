using UnityEngine;

public class ScreenMaterialMessage : EventMessage
{
    public MeshRenderer Renderer { get; private set; }
    public bool State { get; private set; }

    public ScreenMaterialMessage(MeshRenderer renderer, bool state)
    {
        Renderer = renderer;
        State = state;
    }
}

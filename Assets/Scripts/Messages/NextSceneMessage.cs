public class NextSceneMessage : EventMessage 
{
    public int Index { get; private set; }

    public NextSceneMessage(int index)
    {
        Index = index;
    }
}

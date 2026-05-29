public class PauseMessage : EventMessage
{
    public bool Pause { get; private set; }

    public PauseMessage(bool pause)
    {
        Pause = pause;
    }
}

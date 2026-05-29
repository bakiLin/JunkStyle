public class ScreenStateChangedMessage : EventMessage
{
    public string PlatformName { get; private set; }
    public bool State { get; private set; }

    public ScreenStateChangedMessage(string platformName, bool state)
    {
        PlatformName = platformName;
        State = state;
    }
}

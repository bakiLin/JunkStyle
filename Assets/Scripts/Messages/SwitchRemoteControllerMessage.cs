public class SwitchRemoteControllerMessage : EventMessage
{
    public int ID { get; private set; }
    public bool IsOn { get; private set; }

    public SwitchRemoteControllerMessage(int id, bool isOn)
    {
        ID = id;
        IsOn = isOn;
    }
}

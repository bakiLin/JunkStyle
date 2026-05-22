public class SwitchRemoteMessage : EventMessage
{
    public int ID { get; private set; }
    public bool IsOn { get; private set; }

    public SwitchRemoteMessage(int id, bool isOn)
    {
        ID = id;
        IsOn = isOn;
    }
}

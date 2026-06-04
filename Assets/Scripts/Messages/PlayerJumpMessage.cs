public class PlayerJumpMessage : EventMessage
{
    public SoundDataSO SoundData { get; private set; }

    public PlayerJumpMessage(SoundDataSO soundData)
    {
        SoundData = soundData;
    }
}

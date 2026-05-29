public class ResumePlayerMessage : EventMessage
{
    public bool RotateToDefaultValue { get; private set; }

    public ResumePlayerMessage(bool rotateToDefaultValue)
    {
        RotateToDefaultValue = rotateToDefaultValue;
    }
}

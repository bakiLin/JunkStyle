public class AndWire : WireLogic
{
    private bool inputOne, inputTwo;

    public void TurnOn(int index)
    {
        if (index == 0) inputOne = true;
        else inputTwo = true;

        if (inputOne && inputTwo) base.TurnOn();
    }

    public void TurnOff(int index)
    {
        if (index == 0) inputOne = false;
        else inputTwo = false;

        if (!(inputOne && inputTwo)) base.TurnOff();
    }
}

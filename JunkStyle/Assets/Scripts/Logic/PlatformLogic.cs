using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [SerializeField]
    private int platformIndex;

    [SerializeField]
    private int buttonNumber;

    [SerializeField]
    private Platform[] platform;

    private bool[] buttonState;

    private void Start()
    {
        buttonState = new bool[buttonNumber];
        SwitchCaseLogic();
    }

    public void ChangeState(int index)
    {
        buttonState[index] = !buttonState[index];
        SwitchCaseLogic();
    }

    private void SwitchCaseLogic()
    {
        switch (platformIndex)
        {
            case 1:
                One();
                break;
            case 2:
                Two(); 
                break;
        }
    }

    private void One()
    {
        if (buttonState[0]) platform[0].Horizontal();
        else platform[0].Vertical();

        if (!buttonState[0] || buttonState[1] && buttonState[2]) platform[1].Horizontal();
        else platform[1].Vertical();
    }

    private void Two()
    {
        if ((buttonState[0] || buttonState[1]) && (buttonState[2] && buttonState[3])) platform[0].Horizontal();
        else platform[0].Vertical();

        if (buttonState[2] && buttonState[3]) platform[1].Vertical();
        else platform[1].Horizontal();
    }

    private void Three()
    {
        if ((buttonState[0] && buttonState[1]) && !buttonState[2]) platform[0].Vertical();
        else platform[0].Horizontal();

        if (buttonState[2]) platform[1].Horizontal();
        else platform[1].Vertical();
    }

    private void Four()
    {
        if (buttonState[0]) platform[0].Horizontal();
        else platform[0].Vertical();

        if (!buttonState[0] || (buttonState[1] && buttonState[2])) platform[1].Vertical();
        else platform[1].Horizontal();

        if ((buttonState[1] && buttonState[2]) && !buttonState[3]) platform[2].Horizontal();
        else platform[2].Vertical();
    }

    private void Five()
    {
        if (buttonState[0] || buttonState[1]) platform[0].Horizontal();
        else platform[0].Vertical();

        if ((!buttonState[0] && !buttonState[1]) && (buttonState[2] && buttonState[3])) platform[1].Horizontal();
        else platform[1].Vertical();
    }

    private void Six()
    {
        if (buttonState[0]) platform[0].Vertical();
        else platform[0].Horizontal();

        if (buttonState[0] && (!buttonState[1] || buttonState[2] || buttonState[3])) platform[1].Horizontal();
        else platform[1].Vertical();

        if (!buttonState[1] || buttonState[2] || buttonState[3]) platform[2].Horizontal();
        else platform[2].Vertical();
    }
}

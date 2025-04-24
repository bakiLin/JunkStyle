public class LogicTwo : PlatformLogic
{
    protected override void MovePlatform()
    {
        if ((state[0] || state[1]) && (state[2] && state[3])) platforms[0].Horizontal();
        else platforms[0].Vertical();

        if (state[2] && state[3]) platforms[1].Vertical();
        else platforms[1].Horizontal();
    }
}

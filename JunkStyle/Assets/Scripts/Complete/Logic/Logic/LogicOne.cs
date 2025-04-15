public class LogicOne : PlatformLogic
{
    protected override void MovePlatform()
    {
        if (state[0]) platforms[0].Horizontal();
        else platforms[0].Vertical();

        if (!state[0] || state[1] && state[2]) platforms[1].Horizontal();
        else platforms[1].Vertical();
    }
}

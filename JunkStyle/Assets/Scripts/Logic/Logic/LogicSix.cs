public class LogicSix : PlatformLogic
{
    protected override void MovePlatform()
    {
        if (state[0]) 
            platforms[0].Vertical();
        else 
            platforms[0].Horizontal();

        if (state[0] && (!state[1] || state[2] || state[3])) 
            platforms[1].Horizontal();
        else 
            platforms[1].Vertical();

        if (!state[1] || state[2] || state[3]) 
            platforms[2].Horizontal();
        else 
            platforms[2].Vertical();
    }
}
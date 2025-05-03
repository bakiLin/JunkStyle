using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [SerializeField]
    protected int buttonNumber;

    [SerializeField]
    protected Platform[] platforms;

    protected bool[] state;

    protected void Start()
    {
        state = new bool[buttonNumber];
        MovePlatform();
    }

    public void ChangeState(int index)
    {
        state[index] = !state[index];
        MovePlatform();
    }

    protected virtual void MovePlatform() { }
}

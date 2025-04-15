using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [SerializeField]
    protected Platform[] platforms;

    [SerializeField]
    protected Button[] buttons;

    protected bool[] state;

    protected void Start()
    {
        state = new bool[buttons.Length];
        MovePlatform();
    }

    public void ChangeState(int index)
    {
        state[index] = !state[index];
        MovePlatform();
    }

    protected virtual void MovePlatform() { }
}

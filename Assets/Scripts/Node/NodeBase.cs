using UnityEngine;

public abstract class NodeBase : MonoBehaviour
{
    protected bool _currentState;

    public abstract void Switch(bool state);
}

using UnityEngine;

public class NodeElement : MonoBehaviour
{
    [SerializeField] private NodeType _nodeType;
    private bool _currentState;
    private int _activeInputs;

    public (bool, bool) Switch(bool inputState)
    {
        var oldState = _currentState;
        _activeInputs += inputState ? 1 : -1;
        if (_activeInputs < 0) _activeInputs = 0;

        _currentState = _nodeType switch
        {
            NodeType.OR => _activeInputs > 0,
            NodeType.AND => _activeInputs == 2,
            NodeType.NOR => _activeInputs == 0,
            _ => _currentState
        };

        return (oldState != _currentState, _currentState);
    }
}

public enum NodeType { OR, AND, NOR }
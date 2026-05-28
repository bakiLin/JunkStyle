using UnityEngine;

public class NodeElement : NodeBase
{
    enum NodeType { OR, AND, NOR }

    [SerializeField] private NodeType _nodeType;
    [SerializeField] private NodeBase[] _connectedNodes;
    private int _activeInputs;

    public override void Switch(bool state)
    {
        var _oldState = _currentState;
        _activeInputs = Mathf.Max(0, _activeInputs + (state ? 1 : -1));

        _currentState = _nodeType switch {
            NodeType.OR => _activeInputs > 0,
            NodeType.AND => _activeInputs == 2,
            NodeType.NOR => _activeInputs == 0
        };

        if (_currentState == _oldState) return;
        
        foreach (var node in _connectedNodes)
            node.Switch(_currentState);
    }
}
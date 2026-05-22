using MessagePipe;
using System;
using System.Linq;
using UnityEngine;
using VContainer;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private NodeData[] _nodes;
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Material _onMaterial;

    [Inject]
    private void Construct(ISubscriber<SwitchRemoteMessage> switchRemote)
    {
        DisposableBag.Create(
            switchRemote.Subscribe(HandleSwitchRemoteMessage)
        );
    }

    private void HandleSwitchRemoteMessage(SwitchRemoteMessage message)
    {
        var nodeData = _nodes.FirstOrDefault(n => 
            n.RemoteController.Any(r => r.GetInstanceID() == message.ID));

        if (nodeData != null)
            UpdateNode(nodeData, message.IsOn);
    }

    private void UpdateNode(NodeData nodeData, bool state)
    {
        var (changed, newState) = nodeData.Node.Switch(state);
        if (!changed) return;

        var materials = nodeData.WireMeshRenderer.materials;
        materials[0] = newState ? _onMaterial : _offMaterial;
        nodeData.WireMeshRenderer.materials = materials;

        foreach (var node in nodeData.ConnectedNodes)
        {
            var connectedNode = Array.Find(_nodes, x => x.Node == node);
            if (connectedNode != null) 
                UpdateNode(connectedNode, newState);
        }
    }
}

[Serializable]
public class NodeData
{
    [field: SerializeField] public RemoteController[] RemoteController { get; private set; }
    [field: SerializeField] public NodeElement Node { get; private set; }
    [field: SerializeField] public MeshRenderer WireMeshRenderer { get; private set; }
    [field: SerializeField] public NodeElement[] ConnectedNodes { get; private set; }
}

using UnityEngine;

public class NewCheckpointMessage : EventMessage
{
    public Transform Checkpoint;

    public NewCheckpointMessage(Transform checkpoint)
    {
        Checkpoint = checkpoint;
    }
}

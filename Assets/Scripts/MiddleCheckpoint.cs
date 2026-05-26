using MessagePipe;
using UnityEngine;
using VContainer;

public class MiddleCheckpoint : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint;
    private IPublisher<NewCheckpointMessage> _newCheckpoint;

    [Inject]
    private void Construct(IPublisher<NewCheckpointMessage> newCheckpoint)
    {
        _newCheckpoint = newCheckpoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _newCheckpoint.Publish(new NewCheckpointMessage(_checkpoint));
            Destroy(this);
        }
    }
}

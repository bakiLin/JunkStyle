using MessagePipe;
using UnityEngine;
using VContainer;

public class KillFloor : MonoBehaviour
{
    private IPublisher<PlayerKilledMessage> _playerKilled;

    [Inject]
    private void Construct(IPublisher<PlayerKilledMessage> playerKilled)
    {
        _playerKilled = playerKilled;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _playerKilled.Publish(new PlayerKilledMessage());
        }
    }
}

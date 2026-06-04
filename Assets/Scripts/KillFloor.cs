using MessagePipe;
using UnityEngine;
using VContainer;

public class KillFloor : MonoBehaviour
{
    private IPublisher<StopPlayerMessage> _stopPlayer;
    private IPublisher<PlayerKilledMessage> _playerKilled;

    [Inject]
    private void Construct(IPublisher<StopPlayerMessage> stopPlayer,
        IPublisher<PlayerKilledMessage> playerKilled)
    {
        _stopPlayer = stopPlayer;
        _playerKilled = playerKilled;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _stopPlayer.Publish(new StopPlayerMessage());
            _playerKilled.Publish(new PlayerKilledMessage());
        }
    }
}

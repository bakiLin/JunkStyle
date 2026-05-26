using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class PlayerRespawnSystem : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawn;

    [Inject]
    private void Construct(ISubscriber<RespawnPlayerMessage> respawnPlayer,
        ISubscriber<NewCheckpointMessage> newCheckpoint)
    {
        DisposableBag.Create(
            respawnPlayer.Subscribe(_ => Respawn()),
            newCheckpoint.Subscribe(x => _playerSpawn = x.Checkpoint)
        ).AddTo(destroyCancellationToken);
    }

    private void Respawn()
    {
        transform.position = _playerSpawn.position;
        transform.rotation = _playerSpawn.rotation;
    }
}

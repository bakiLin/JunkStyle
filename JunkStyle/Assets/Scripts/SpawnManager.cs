using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform[] spawnPoints;

    private int index;

    public void Respawn() => player.position = spawnPoints[index].position;

    public void SpawnPoint() => index++;
}

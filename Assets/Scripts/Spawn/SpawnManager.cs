using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    [Inject]
    private PlayerJump playerJump;

    private Transform player;

    private Transform[] spawnPoints;

    private int index;

    private void Awake()
    {
        player = playerJump.transform;
    }

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = transform.GetChild(i);
    }

    public void Respawn()
    {
        player.position = spawnPoints[index].position;
    }

    public void SpawnPoint()
    {
        index++;
    }
}

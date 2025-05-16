using UnityEngine;
using Zenject;

public class SpawnPoint : MonoBehaviour
{
    [Inject]
    private SpawnManager spawnManager;

    private bool touch;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !touch)
        {
            touch = true;
            spawnManager.SpawnPoint();
        }
    }
}
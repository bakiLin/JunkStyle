using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
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
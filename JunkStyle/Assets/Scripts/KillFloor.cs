using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class KillFloor : MonoBehaviour
{
    [SerializeField]
    private Image blackout;

    [SerializeField]
    private SpawnManager spawnManager;

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            await blackout.DOFade(1f, 1f).AsyncWaitForCompletion();
            spawnManager.Respawn();
            await UniTask.Delay(500);
            blackout.DOFade(0f, 1f);
        }
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            await blackout.DOFade(1f, 1f).AsyncWaitForCompletion();
            spawnManager.Respawn();
            await UniTask.Delay(500);
            blackout.DOFade(0f, 1f);
        }
    }
}

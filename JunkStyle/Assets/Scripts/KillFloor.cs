using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Zenject;

public class KillFloor : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [Inject]
    private PauseManager pauseManager;

    [SerializeField]
    private Image blackout;

    [Inject]
    private SpawnManager spawnManager;

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            pauseManager.canPause = false;
            audioManager.Play("killfloor", .2f);
            await blackout.DOFade(1f, 1f).AsyncWaitForCompletion();
            spawnManager.Respawn();
            await UniTask.Delay(500);
            await blackout.DOFade(0f, 1f).AsyncWaitForCompletion();
            pauseManager.canPause = true;
        }
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pauseManager.canPause = false;
            audioManager.Play("killfloor", .2f);
            await blackout.DOFade(1f, 1f).AsyncWaitForCompletion();
            spawnManager.Respawn();
            await UniTask.Delay(500);
            await blackout.DOFade(0f, 1f).AsyncWaitForCompletion();
            pauseManager.canPause = true;
        }
    }
}

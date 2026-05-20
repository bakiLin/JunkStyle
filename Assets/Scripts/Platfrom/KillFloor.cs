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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Respawn();
    }

    private async void Respawn()
    {
        audioManager.Play("killfloor", .2f);
        pauseManager.NoPause(false);
        await blackout.DOFade(1f, 1f).AsyncWaitForCompletion();
        spawnManager.Respawn();
        await UniTask.Delay(500);
        await blackout.DOFade(0f, 1f).AsyncWaitForCompletion();
        pauseManager.NoPause(true);
    }
}

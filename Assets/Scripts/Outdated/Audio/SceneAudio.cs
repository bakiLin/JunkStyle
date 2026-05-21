using UnityEngine;
using Zenject;

public class SceneAudio : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private string sceneAudio;

    [SerializeField]
    private bool dontPlayOnAwake;

    private void Start()
    {
        if (!dontPlayOnAwake && !audioManager.IsPlaying(sceneAudio))
            audioManager.Play(sceneAudio, 0f);
    }

    public void ClickSound()
    {
        audioManager.Play("click", .3f);
    }

    public void PlaySceneAudio()
    {
        audioManager.Play(sceneAudio, 0f);
    }

    public void StopSceneAudio()
    {
        audioManager.Stop(sceneAudio);
    }
}

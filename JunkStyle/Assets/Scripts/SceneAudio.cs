using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneAudio : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private string sceneMusic;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            audioManager.Play(sceneMusic, 0f);
        else
            audioManager.Play("menu", 0f);
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            audioManager.Stop(sceneMusic);
    }

    public void ClickSound()
    {
        audioManager.Play("click", .3f);
    }

    public void StopTheme()
    {
        audioManager.Stop("theme");
    }
}

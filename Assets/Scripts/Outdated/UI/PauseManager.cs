using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseManager : MonoBehaviour
{
    [Inject]
    private TapManager tapManager;

    [Inject]
    private CursorManager cursorManager;

    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private GameObject pauseWindow;

    private bool noPause, isPaused;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            noPause = true;
            tapManager.StopRaycast(true);
            cursorManager.Unlock();
            Time.timeScale = 0f;
        }
    }

    private void OnDestroy() => Time.timeScale = 1f;

    public void Pause()
    {
        if (!noPause)
        {
            if (!isPaused) PauseState(true);
            else PauseState(false);
        }
    }

    public void SkipInstruction()
    {
        noPause = false;
        PauseState(false);
    }

    public void NoPause(bool state) => noPause = state;

    private void PauseState(bool state)
    {
        isPaused = state;
        tapManager.StopRaycast(state);

        if (state)
        {
            audioManager.Stop("theme");
            audioManager.Play("menu", 0f);
            pauseWindow.SetActive(true);
            cursorManager.Unlock();
            Time.timeScale = 0f;
        }
        else
        {
            audioManager.Stop("menu");
            audioManager.Play("theme", 0f);
            pauseWindow.SetActive(false);
            cursorManager.Lock();
            Time.timeScale = 1f;
        }
    }
}

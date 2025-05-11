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

    private bool isPaused;

    public bool canPause;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            canPause = false;
            isPaused = true;
            tapManager.StopRaycast(true);
            cursorManager.Unlock();
            Time.timeScale = 0f;
        }
    }

    public void SkipInstruction()
    {
        audioManager.Stop("menu");
        audioManager.Play("theme", 0f);

        canPause = true;
        isPaused = false;
        tapManager.StopRaycast(false);
        cursorManager.Lock();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if (canPause)
        {
            print("pause");

            if (!isPaused)
            {
                audioManager.Stop("theme");
                audioManager.Play("menu", 0f);

                isPaused = true;
                tapManager.StopRaycast(true);
                pauseWindow.SetActive(true);
                cursorManager.Unlock();
                Time.timeScale = 0f;
            }
            else
            {
                audioManager.Stop("menu");
                audioManager.Play("theme", 0f);

                isPaused = false;
                tapManager.StopRaycast(false);
                pauseWindow.SetActive(false);
                cursorManager.Lock();
                Time.timeScale = 1f;
            }
        }
    }
}

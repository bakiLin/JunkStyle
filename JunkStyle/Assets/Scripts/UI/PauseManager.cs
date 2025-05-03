using UnityEngine;
using Zenject;

public class PauseManager : MonoBehaviour
{
    [Inject]
    private TapManager tapManager;

    [Inject]
    private CursorManager cursorManager;

    [SerializeField]
    private GameObject pauseWindow;

    private bool isPaused;

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            tapManager.StopRaycast(true);
            pauseWindow.SetActive(true);
            cursorManager.Unlock();
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            tapManager.StopRaycast(false);
            pauseWindow.SetActive(false);
            cursorManager.Lock();
            Time.timeScale = 1f;
        }
    }
}

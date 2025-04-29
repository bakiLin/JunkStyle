using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private TapManager tapManager;

    private bool isPaused;

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            tapManager.StopRaycast(true);
            canvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = false;
            tapManager.StopRaycast(false);
            canvas.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

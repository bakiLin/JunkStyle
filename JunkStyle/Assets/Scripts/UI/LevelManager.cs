using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [Inject]
    private CursorManager cursorManager;

    [SerializeField]
    private Image blackoutImage;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioManager.Stop("theme");
            cursorManager.Unlock();
        }

        blackoutImage.DOFade(0f, 1f).SetUpdate(true);
    }

    public void LoadLevel(int index)
    {
        blackoutImage.DOFade(1f, 1f).OnComplete(() => {
            SceneManager.LoadScene(index);
        }).SetUpdate(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
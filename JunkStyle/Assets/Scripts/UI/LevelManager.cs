using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [Inject]
    private CursorManager cursorManager;

    [SerializeField]
    private Image blackoutImage;

    private void Start()
    {
        blackoutImage.DOFade(0f, 1f).SetUpdate(true);
    }

    public void NextLevel()
    {
        blackoutImage.DOFade(1f, 1f).OnComplete(() => {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                cursorManager.Unlock();
                SceneManager.LoadScene(0);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }

    public void LoadLevel(int index)
    {
        blackoutImage.DOFade(1f, 1f).OnComplete(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene(index);
        }).SetUpdate(true);
    }
}
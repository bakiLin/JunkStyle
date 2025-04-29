using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image blackout;

    public void LoadNext()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        blackout.DOFade(1f, 1f).OnComplete(() => {
            if (currentScene == 3)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(0);
            }
            else
                SceneManager.LoadScene(currentScene + 1);
        });
    }

    public void LoadLevel(int index)
    {
        blackout.DOFade(1f, 1f).OnComplete(() => {
            SceneManager.LoadScene(index);
        });
    }
}
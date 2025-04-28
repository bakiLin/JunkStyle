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

        blackout.DOFade(1f, 1f).OnComplete(() =>
        {
            if (currentScene == 2)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(currentScene + 1);
        });
    }
}
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
        if (currentScene + 1 == SceneManager.sceneCount) currentScene = 0;

        blackout.DOFade(1f, 1f).OnComplete(() =>
        {
            SceneManager.LoadScene(currentScene + 1);
        });
    }
}
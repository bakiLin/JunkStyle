using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image blackoutImage;

    private void Start()
    {
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
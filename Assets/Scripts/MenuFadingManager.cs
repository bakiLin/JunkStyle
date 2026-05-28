using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class MenuFadingManager : MonoBehaviour
{
    private UISettingsSO _settings;
    private Image _faderImage;

    [Inject]
    private void Construct(UISettingsSO settings)
    {
        _settings = settings;
        _faderImage = GetComponent<Image>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartFade().Forget();
    }

    private async UniTask StartFade()
    {
        await UniTask.Delay(100, cancellationToken: destroyCancellationToken);
        await ImageFader.FadeImage(_faderImage, 0f, _settings.FadeDuration, destroyCancellationToken);
        _faderImage.raycastTarget = false;
    }

    public async void LoadLevel(int index)
    {
        _faderImage.raycastTarget = true;
        var operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        await ImageFader.FadeImage(_faderImage, 1f, _settings.FadeDuration, destroyCancellationToken);
        operation.allowSceneActivation = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

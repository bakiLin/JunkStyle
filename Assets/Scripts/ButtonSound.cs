using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private SoundDataSO _buttonSound;
    private Button _button;
    private ISoundManager _soundManager;

    [Inject]
    private void Construct(ISoundManager soundManager)
    {
        _soundManager = soundManager;
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(() => {
            _soundManager.Get()
            .Play(_buttonSound, Vector3.zero, destroyCancellationToken).Forget();
        });
    }
}

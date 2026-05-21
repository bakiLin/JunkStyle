using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScrollbarManager : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private Slider music;

    private void Start()
    {
        music.value = (audioManager.GetMusic() / 20 + 1) < 0 ? 0 : (audioManager.GetMusic() / 20 + 1);
        music.onValueChanged.AddListener((float volume) => audioManager.SetMusic(volume));
    }
}

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
        SetScrollbar(ref music, audioManager.GetMusic() / 20 + 1);
        music.onValueChanged.AddListener((float volume) => audioManager.SetMusic(volume));
    }

    private void SetScrollbar(ref Slider scrollbar, float mixerValue)
    {
        scrollbar.value = mixerValue < 0 ? 0 : mixerValue;
    }
}

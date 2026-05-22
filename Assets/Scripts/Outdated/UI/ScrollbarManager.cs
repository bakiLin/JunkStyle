using UnityEngine;
using UnityEngine.UI;

public class ScrollbarManager : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    private Slider music;

    private void Start()
    {
        music.value = (audioManager.GetMusic() / 20 + 1) < 0 ? 0 : (audioManager.GetMusic() / 20 + 1);
        music.onValueChanged.AddListener((float volume) => audioManager.SetMusic(volume));
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", (volume - 1) * 20);
        if (volume == 0f) audioMixer.SetFloat("Music", -80f);
    }

    public float GetMusic()
    {
        float volume;
        audioMixer.GetFloat("Music", out volume);
        return volume;
    }
}

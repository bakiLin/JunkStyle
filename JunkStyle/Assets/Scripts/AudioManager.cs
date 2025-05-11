using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.outputAudioMixerGroup = sound.Output;
            sound.Source.volume = sound.Volume;
            sound.Source.loop = sound.Loop;
        }
    }

    public void Play(string name, float startPoint)
    {
        Sound s = Array.Find(sounds, s => s.Name == name);
        if (s != null)
        {
            if (startPoint != 0) s.Source.time = startPoint;
            s.Source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, s => s.Name == name);
        if (s != null) s.Source.Stop();
    }

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

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;
    public AudioMixerGroup Output;
    public float Volume;
    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}

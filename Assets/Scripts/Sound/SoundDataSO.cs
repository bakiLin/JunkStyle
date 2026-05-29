using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Scriptable Object/Settings/Sound Data", fileName = "SoundData")]
public class SoundDataSO : ScriptableObject
{
    [field: SerializeField] public AudioClip[] Clip { get; private set; }
    [field: SerializeField] public AudioMixerGroup Mixer { get; private set; }
    [field: SerializeField] public bool Loop { get; private set; }
    [field: SerializeField] public bool RandomPitch { get; private set; }

    [field: Space, Header("3D Settings")]
    [field: SerializeField, Range(0f, 1f)] public float SpatialBlend { get; private set; }
    [field: SerializeField, Range(0f, 360f)] public float Spread { get; private set; }
    [field: SerializeField] public float MinDistance { get; private set; }
    [field: SerializeField] public float MaxDistance { get; private set; }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Settings/Material Settings", fileName = "MaterialSettings")]
public class MaterialSettingsSO : ScriptableObject
{
    [field: SerializeField] public Material RemoteOn { get; private set; }
    [field: SerializeField] public Material RemoteOff { get; private set; }
    [field: SerializeField] public Material WireOn { get; private set; }
    [field: SerializeField] public Material WireOff { get; private set; }
    [field: SerializeField] public Material ScreenOn { get; private set; }
    [field: SerializeField] public Material ScreenOff { get; private set; }
}

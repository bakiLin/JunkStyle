using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Settings/Remote Controller", fileName = "RemoteControllerSettings")]
public class RemoteSettingsSO : ScriptableObject
{
    [field: SerializeField] public Vector3 OnRotation { get; private set; }
    [field: SerializeField] public Vector3 OffRotation { get; private set; }
    [field: SerializeField] public Material LightOnMaterial { get; private set; }
    [field: SerializeField] public Material LightOffMaterial { get; private set; }
}

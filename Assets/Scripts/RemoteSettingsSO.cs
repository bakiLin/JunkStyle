using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Settings/Remote Settings", fileName = "RemoteSettings")]
public class RemoteSettingsSO : ScriptableObject
{
    [field: SerializeField] public Vector3 OnRotation { get; private set; }
    [field: SerializeField] public Vector3 OffRotation { get; private set; }
}

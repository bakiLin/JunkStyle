using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Settings/UI Settings", fileName = "UISettings")]
public class UISettingsSO : ScriptableObject
{
    [field: SerializeField] public float FadeDuration { get; private set; }
    [field: SerializeField] public float FadeDelay { get; private set; }
}

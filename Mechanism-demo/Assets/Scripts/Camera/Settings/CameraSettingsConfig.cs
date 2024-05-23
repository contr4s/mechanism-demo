using UnityEngine;

namespace Camera.Settings
{
    [CreateAssetMenu(fileName = "CameraSettingsCfg", menuName = "Configs/Camera", order = 0)]
    public class CameraSettingsConfig : ScriptableObject
    {
        [field: SerializeField] public CameraParameters DefaultParameters { get; private set; }
    }
}
using System;
using UnityEngine;

namespace Camera.Settings
{
    [Serializable]
    public class CameraParameters
    {
        [field: SerializeField] public float Fov { get; private set; }
        [field: SerializeField] public Offsets Offsets { get; private set; }
    }
}
using System;
using UnityEngine;

namespace Camera.Settings
{
    [Serializable]
    public class Offsets
    {
        public const int Count = 3;
        
        [field: SerializeField] public Vector3 Top { get; private set; }
        [field: SerializeField] public Vector3 Middle { get; private set; }
        [field: SerializeField] public Vector3 Bottom { get; private set; }

        public Vector3 this[int index] => index switch
                {
                        0 => Top,
                        1 => Middle,
                        2 => Bottom,
                        _ => throw new ArgumentOutOfRangeException(nameof(index), index,
                                                                   "There are only 3 dimensions of offsets")
                };

        public static Offsets Zero => new Offsets {Top = Vector3.zero, Middle = Vector3.zero, Bottom = Vector3.zero};
    }
}
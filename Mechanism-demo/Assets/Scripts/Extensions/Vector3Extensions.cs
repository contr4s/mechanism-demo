
using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static bool Approximately(this Vector3 first, Vector3 second)
        {
            return Mathf.Approximately(first.x, second.x) && Mathf.Approximately(first.y, second.y) && Mathf.Approximately(first.z, second.z);
        }
    }
}
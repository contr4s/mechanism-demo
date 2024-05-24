using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Animation
{
    public abstract class AppearAnimation : MonoBehaviour
    {
        public abstract UniTask ShowAnimation(CancellationToken ct);

        public abstract UniTask HideAnimation(CancellationToken ct);
    }
}
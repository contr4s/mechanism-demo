using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Animation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Window
{
    public abstract class WindowView : UIBehaviour
    {
        [SerializeField] private AppearAnimation _animation;

        private bool _hasAnimation;
        public bool IsShown { get; private set; }

        public virtual void InstantlyShow()
        {
            IsShown = true;
        }
        
        public virtual void InstantlyHide()
        {
            IsShown = false;
        }

        public async UniTask Show(CancellationToken ct)
        {
            InstantlyShow();
            if (_hasAnimation)
            {
                await _animation.ShowAnimation(ct);
            }

            if (ct.IsCancellationRequested)
            {
                InstantlyHide();
            }
        }

        public async UniTask Hide(CancellationToken ct)
        {
            if (_hasAnimation)
            {
                await _animation.HideAnimation(ct);
            }

            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            InstantlyHide();
        }

        protected override void Awake()
        {
            base.Awake();
            _hasAnimation = _animation != null;
        }
    }
}
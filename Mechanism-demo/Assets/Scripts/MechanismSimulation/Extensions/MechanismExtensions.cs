using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using UnityEngine;

namespace MechanismSimulation.Extensions
{
    public static class MechanismExtensions
    {
        public static void ShowAllParts(this IMechanism mechanism)
        {
            foreach (IMechanismPart mechanismPart in mechanism.Parts)
            {
                mechanismPart.View.SetActive(true);
            }
        }
        
        public static void HideAllParts(this IMechanism mechanism)
        {
            foreach (IMechanismPart mechanismPart in mechanism.Parts)
            {
                mechanismPart.View.SetActive(false);
            }
        }
        
        public static async UniTask SwitchBlastState(this IMechanism mechanism, bool isBlast, float speed, CancellationToken ct)
        {
            mechanism.SwitchBlastState();
            
            bool flag = true;
            while (flag && !ct.IsCancellationRequested)
            {
                flag = false;
                foreach (IMechanismPart part in mechanism.Parts)
                {
                    var pos = part.View.transform.localPosition;
                    var targetPos = isBlast ? part.BlastedOffset : part.StartOffset;
                    if (pos.Approximately(targetPos))
                    {
                        continue;
                    }

                    flag = true;
                    part.View.transform.localPosition = Vector3.Lerp(pos, targetPos, speed * Time.deltaTime);
                }
                
                await UniTask.Yield(PlayerLoopTiming.Update, ct);
            }
        }
    }
}
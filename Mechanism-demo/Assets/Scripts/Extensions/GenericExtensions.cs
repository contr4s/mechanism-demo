using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Extensions
{
    public static class GenericExtensions
    {
        public static async UniTask ChangeParameterSmooth<TObj>(this TObj obj,
                                                                Func<TObj, float> getParamFunc,
                                                                Action<TObj, float> setParamFunc,
                                                                float targetVal,
                                                                float smoothSpeed,
                                                                CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                float cur = getParamFunc(obj);
                if (Mathf.Approximately(cur, targetVal))
                {
                    return;
                }

                setParamFunc(obj, Mathf.Lerp(cur, targetVal, smoothSpeed * Time.deltaTime));
                await UniTask.Yield(PlayerLoopTiming.Update, ct);
            }
        }
        
        public static async UniTask ChangeParameterSmooth<TObj>(this TObj obj,
                                                                Func<TObj, Vector3> getParamFunc,
                                                                Action<TObj, Vector3> setParamFunc,
                                                                Vector3 targetVal,
                                                                float smoothSpeed,
                                                                CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                Vector3 cur = getParamFunc(obj);
                if (cur.Approximately(targetVal))
                {
                    return;
                }

                setParamFunc(obj, Vector3.Lerp(cur, targetVal, smoothSpeed * Time.deltaTime));
                await UniTask.Yield(PlayerLoopTiming.Update, ct);
            }
        }
    }
}
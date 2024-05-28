using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Scene
{
    public static class SceneUtil
    {
        public static async UniTask LoadScene(int index, CancellationToken ct, int curIndex = -1)
        {
            if (curIndex != -1)
            {
                await SceneManager.UnloadSceneAsync(curIndex);
            }

            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            await SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            await UniTask.Yield(ct);
        }
    }
}
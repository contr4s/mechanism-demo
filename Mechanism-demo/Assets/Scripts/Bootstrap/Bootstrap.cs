using UnityEngine.SceneManagement;
using Zenject;

namespace Bootstrap
{
    public class Bootstrap : IInitializable
    {
        public void Initialize()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}

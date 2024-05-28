using UnityEngine;
using Zenject;

namespace Scene
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private SceneConfig sceneConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(sceneConfig).AsSingle();
        }
    }
}
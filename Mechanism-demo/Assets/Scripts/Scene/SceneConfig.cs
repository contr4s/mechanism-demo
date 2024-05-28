using UnityEngine;

namespace Scene
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/Scene", order = 0)]
    public class SceneConfig : ScriptableObject
    {
        [field: SerializeField] public int StartSceneIndex { get; private set; }
        [field: SerializeField] public int SimulationSceneIndex { get; private set; }
    }
}
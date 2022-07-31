using UnityEngine;

namespace _Shared
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _charactersSpawnPointsRoot;

        public Transform CharactersSpawnPointsRoot => _charactersSpawnPointsRoot;
    }
}
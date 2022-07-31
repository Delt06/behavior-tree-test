using Characters;
using UnityEngine;

namespace _Shared
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private CharacterResourceView _characterResourceViewPrefab;

        public GameObject CharacterPrefab => _characterPrefab;
        public CharacterResourceView CharacterResourceViewPrefab => _characterResourceViewPrefab;
    }
}
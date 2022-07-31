using Game.Characters;
using UnityEngine;

namespace Game._Shared
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [SerializeField] private CharacterContext _characterPrefab;
        [SerializeField] private CharacterResourceView _characterResourceViewPrefab;

        public CharacterContext CharacterPrefab => _characterPrefab;
        public CharacterResourceView CharacterResourceViewPrefab => _characterResourceViewPrefab;
    }
}
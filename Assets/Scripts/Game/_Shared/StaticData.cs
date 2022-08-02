using Game.Characters;
using UnityEngine;

namespace Game._Shared
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [SerializeField] private CharacterContext _characterPrefab;
        [SerializeField] private CharacterResourceView _characterResourceViewPrefab;
        [SerializeField] [Min(0)] private int _characterResourceCapacity = 2;

        public CharacterContext CharacterPrefab => _characterPrefab;
        public CharacterResourceView CharacterResourceViewPrefab => _characterResourceViewPrefab;

        public int CharacterResourceCapacity => _characterResourceCapacity;
    }
}
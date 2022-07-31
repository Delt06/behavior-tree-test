using UnityEngine;

namespace Game.Characters
{
    public class CharacterContext : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Movement _movement;

        public CharacterModel Model { get; private set; }

        public GameObject Root => _root;

        public Movement Movement => _movement;

        public void Init(CharacterModel model) => Model = model;
    }
}
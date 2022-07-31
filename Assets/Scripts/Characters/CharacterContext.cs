using UnityEngine;

namespace Characters
{
    public class CharacterContext : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Movement _movement;

        public GameObject Root => _root;

        public Movement Movement => _movement;
    }
}
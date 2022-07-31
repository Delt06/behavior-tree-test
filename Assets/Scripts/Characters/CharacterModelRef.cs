using UnityEngine;

namespace Characters
{
    public class CharacterModelRef : MonoBehaviour
    {
        public CharacterModel Model { get; private set; }

        public void Init(CharacterModel model)
        {
            Model = model;
        }
    }
}
using UnityEngine;

namespace Characters
{
    public interface ICharacterFactory
    {
        void Create(Vector2 position);
    }
}
using UnityEngine;

namespace Game.Characters
{
    public interface ICharacterFactory
    {
        void Create(Vector2 position);
    }
}
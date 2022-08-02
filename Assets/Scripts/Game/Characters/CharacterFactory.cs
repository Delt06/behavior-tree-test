using Game._Shared;
using UnityEngine;

namespace Game.Characters
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly StaticData _staticData;

        public CharacterFactory(StaticData staticData) => _staticData = staticData;

        public void Create(Vector2 position)
        {
            var gameObject = Object.Instantiate(_staticData.CharacterPrefab, position, Quaternion.identity);
            var model = new CharacterModel(_staticData.CharacterResourceCapacity);
            gameObject.GetComponent<CharacterContext>().Init(model);

            var resourceViewModel = new CharacterResourceViewModel(model);

            var characterResourceView =
                Object.Instantiate(_staticData.CharacterResourceViewPrefab, gameObject.transform);
            characterResourceView.Init(resourceViewModel);
        }
    }
}
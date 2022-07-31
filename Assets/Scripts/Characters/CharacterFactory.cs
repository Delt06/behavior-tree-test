using _Shared;
using UnityEngine;

namespace Characters
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly StaticData _staticData;

        public CharacterFactory(StaticData staticData) => _staticData = staticData;

        public void Create(Vector2 position)
        {
            var gameObject = Object.Instantiate(_staticData.CharacterPrefab, position, Quaternion.identity);
            var model = new CharacterModel();
            gameObject.GetComponent<CharacterModelRef>().Init(model);

            var resourceViewModel = new CharacterResourceViewModel(model);

            var characterResourceView =
                Object.Instantiate(_staticData.CharacterResourceViewPrefab, gameObject.transform);
            characterResourceView.Init(resourceViewModel);
        }
    }
}
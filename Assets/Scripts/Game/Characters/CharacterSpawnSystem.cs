using DELTation.DIFramework.Systems;
using Game._Shared;
using UnityEngine;

namespace Game.Characters
{
    public class CharacterSpawnSystem : IInitSystem
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly SceneData _sceneData;

        public CharacterSpawnSystem(ICharacterFactory characterFactory, SceneData sceneData)
        {
            _characterFactory = characterFactory;
            _sceneData = sceneData;
        }

        public void Init()
        {
            foreach (Transform spawnPoint in _sceneData.CharactersSpawnPointsRoot)
            {
                _characterFactory.Create(spawnPoint.position);
            }
        }
    }
}
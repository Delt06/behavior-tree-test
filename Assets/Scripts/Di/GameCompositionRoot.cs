using DELTation.DIFramework;
using DELTation.DIFramework.Containers;
using Game._Shared;
using Game.Characters;
using Game.ResourceSystem;
using UnityEngine;

namespace Di
{
    public class GameCompositionRoot : DependencyContainerBase
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ResourceRepository _resourceRepository;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            // data
            builder
                .Register(_staticData)
                .Register(_sceneData)
                ;

            // systems
            builder.Register<GameSystemsRunner>();

            // services
            builder
                .Register<CharacterFactory>()
                .Register(_resourceRepository)
                ;
        }
    }
}
using DELTation.DIFramework.Systems;
using Game.Characters;

namespace Di
{
    public class GameSystemsRunner : SystemsRunnerBase
    {
        protected override void ConstructSystems()
        {
            Add<CharacterSpawnSystem>();
        }
    }
}
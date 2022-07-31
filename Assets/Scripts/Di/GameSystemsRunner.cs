using Characters;
using DELTation.DIFramework.Systems;

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
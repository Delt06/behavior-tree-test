using Game.Characters;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;

namespace Game.Ai.Nodes
{
    public class FreeResourcesNode : BehaviorTreeNodeBase<CharacterContext>
    {
        public override EvaluationStatus Evaluate(CharacterContext context)
        {
            context.Model.FreeResources();
            return EvaluationStatus.Success;
        }
    }
}
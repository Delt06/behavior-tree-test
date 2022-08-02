using Game.Characters;
using Modules.BehaviorTrees.Nodes.Conditions;

namespace Game.Ai.Nodes
{
    public sealed class CharacterResourcesAreFullConditionNode : BehaviorTreeConditionNodeBase<CharacterContext>
    {
        protected override bool Condition(CharacterContext context) => context.Model.IsFull;
    }
}
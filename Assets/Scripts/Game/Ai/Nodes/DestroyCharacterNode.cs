using Game.Characters;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;

namespace Game.Ai.Nodes
{
    public class DestroyCharacterNode : BehaviorTreeNodeBase<CharacterContext>
    {
        public override EvaluationStatus Evaluate(CharacterContext context)
        {
            Object.Destroy(context.Root);
            return EvaluationStatus.Success;
        }
    }
}
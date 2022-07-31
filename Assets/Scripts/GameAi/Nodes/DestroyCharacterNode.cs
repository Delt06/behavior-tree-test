using BehaviorTrees;
using BehaviorTrees.Nodes;
using Characters;
using UnityEngine;

namespace GameAi.Nodes
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
using BehaviorTrees;
using BehaviorTrees.Nodes;
using Characters;
using UnityEngine;

namespace GameAi.Nodes
{
    public class SetDirectionNode : BehaviorTreeNodeBase<CharacterContext>
    {
        private readonly Vector2 _direction;

        public SetDirectionNode(Vector2 direction) => _direction = direction;

        public override EvaluationStatus Evaluate(CharacterContext context)
        {
            context.Movement.Direction = _direction;
            return EvaluationStatus.Success;
        }
    }
}
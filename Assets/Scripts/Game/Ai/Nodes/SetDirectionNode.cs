using Game.Characters;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;

namespace Game.Ai.Nodes
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
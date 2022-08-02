using Game.Characters;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;

namespace Game.Ai.Nodes
{
    public class MoveTowardsPosition : BehaviorTreeNodeBase<CharacterContext>
    {
        private readonly float _reachThresholdSqr;
        private readonly Vector3 _targetPosition;

        public MoveTowardsPosition(Vector3 targetPosition, float reachThreshold)
        {
            _targetPosition = targetPosition;
            _reachThresholdSqr = reachThreshold * reachThreshold;
        }

        public override EvaluationStatus Evaluate(CharacterContext context)
        {
            var offset = _targetPosition - context.Movement.transform.position;
            if (offset.sqrMagnitude < _reachThresholdSqr)
                return EvaluationStatus.Success;

            var direction = offset.normalized;
            context.Movement.Direction = direction;
            return EvaluationStatus.Running;
        }
    }
}
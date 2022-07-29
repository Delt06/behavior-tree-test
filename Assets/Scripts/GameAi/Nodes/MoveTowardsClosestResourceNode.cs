using BehaviorTrees;
using BehaviorTrees.Nodes;
using JetBrains.Annotations;
using UnityEngine;

namespace GameAi.Nodes
{
    public class MoveTowardsClosestResourceNode : BehaviorTreeNodeBase<CharacterContext>
    {
        [CanBeNull]
        private Resource _resource;

        public override void ResetState(CharacterContext context)
        {
            _resource = null;
        }

        public override EvaluationStatus Evaluate(CharacterContext context)
        {
            if (_resource is not null && _resource.IsCollected)
                return EvaluationStatus.Success;

            if (_resource is null)
            {
                var minDistance = float.PositiveInfinity;
                var closestResource = default(Resource);

                foreach (var resource in context.ResourceRepository.Resources)
                {
                    var distance = Vector3.Distance(context.Movement.transform.position, resource.transform.position);
                    if (distance > minDistance) continue;

                    closestResource = resource;
                    minDistance = distance;
                }

                if (closestResource is null)
                    return EvaluationStatus.Failure;

                _resource = closestResource;
            }

            var direction = (_resource.transform.position - context.Movement.transform.position).normalized;
            context.Movement.Direction = direction;
            return EvaluationStatus.Running;
        }
    }
}
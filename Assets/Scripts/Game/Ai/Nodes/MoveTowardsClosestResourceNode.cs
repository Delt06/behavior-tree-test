using Game.Characters;
using Game.ResourceSystem;
using JetBrains.Annotations;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;

namespace Game.Ai.Nodes
{
    public class MoveTowardsClosestResourceNode : BehaviorTreeNodeBase<CharacterContext>
    {
        [CanBeNull]
        private Resource _resource;
        private readonly ResourceRepository _resourceRepository;

        public MoveTowardsClosestResourceNode(ResourceRepository resourceRepository) =>
            _resourceRepository = resourceRepository;

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

                foreach (var resource in _resourceRepository.Resources)
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
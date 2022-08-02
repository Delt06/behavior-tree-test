using Game.Characters;
using Game.ResourceSystem;
using JetBrains.Annotations;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using Modules.Math;
using UnityEngine;

namespace Game.Ai.Nodes
{
    public class MoveTowardsRandomResourceNode : BehaviorTreeNodeBase<CharacterContext>
    {
        private readonly float _reachThresholdSqr;
        private readonly ResourceRepository _resourceRepository;
        [CanBeNull]
        private Resource _resource;

        public MoveTowardsRandomResourceNode(ResourceRepository resourceRepository, float reachThreshold)
        {
            _resourceRepository = resourceRepository;
            _reachThresholdSqr = reachThreshold * reachThreshold;
        }

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
                if (RandomUtils.TryGetRandom(_resourceRepository.Resources, out var selectedResource))
                    _resource = selectedResource;
                else
                    return EvaluationStatus.Failure;
            }

            var offset = _resource!.transform.position - context.Movement.transform.position;
            if (offset.sqrMagnitude < _reachThresholdSqr)
            {
                context.Movement.Direction = Vector2.zero;
            }
            else
            {
                var direction = offset.normalized;
                context.Movement.Direction = direction;
            }

            return EvaluationStatus.Running;
        }
    }
}
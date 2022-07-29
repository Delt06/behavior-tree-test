using System;
using Random = UnityEngine.Random;

namespace BehaviorTrees.Nodes.Utility
{
    public sealed class RandomChanceNode<TContext> : BehaviorTreeNodeBase<TContext>
    {
        private readonly float _probability;
        private bool? _result;

        public RandomChanceNode(float probability) => _probability = probability;

        public override EvaluationStatus Evaluate(TContext context)
        {
            _result ??= Random.value <= _probability;
            return _result switch
            {
                true => EvaluationStatus.Success,
                false => EvaluationStatus.Failure,
                _ => throw new ArgumentOutOfRangeException(nameof(_result)),
            };
        }

        public override void ResetState(TContext context) => _result = null;
    }
}
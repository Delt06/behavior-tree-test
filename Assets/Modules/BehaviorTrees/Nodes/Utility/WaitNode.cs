using UnityEngine;

namespace Modules.BehaviorTrees.Nodes.Utility
{
    public sealed class WaitNode<TContext> : BehaviorTreeNodeBase<TContext>
    {
        private readonly float _duration;
        private float _elapsedTime;

        public WaitNode(float seconds) => _duration = seconds;

        public override void ResetState(TContext context)
        {
            _elapsedTime = 0f;
        }

        public override EvaluationStatus Evaluate(TContext context)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _duration) return EvaluationStatus.Running;

            return EvaluationStatus.Success;
        }
    }
}
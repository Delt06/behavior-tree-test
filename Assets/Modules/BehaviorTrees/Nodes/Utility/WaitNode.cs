using UnityEngine;

namespace Modules.BehaviorTrees.Nodes.Utility
{
    public sealed class WaitNode<TContext> : BehaviorTreeNodeBase<TContext>
    {
        private readonly Vector2 _duration;
        private float? _currentDuration;
        private float _elapsedTime;

        public WaitNode(float seconds) => _duration = new Vector2(seconds, seconds);

        public WaitNode(float secondsMin, float secondsMax) =>
            _duration = new Vector2(secondsMin, secondsMax);

        public override void ResetState(TContext context)
        {
            _elapsedTime = 0f;
            _currentDuration = null;
        }

        public override EvaluationStatus Evaluate(TContext context)
        {
            _currentDuration ??= Random.Range(_duration.x, _duration.y);

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _currentDuration) return EvaluationStatus.Running;

            _currentDuration = null;
            return EvaluationStatus.Success;
        }
    }
}
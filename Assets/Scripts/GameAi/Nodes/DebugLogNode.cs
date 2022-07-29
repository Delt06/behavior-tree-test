using System;
using BehaviorTrees;
using BehaviorTrees.Nodes;
using UnityEngine;

namespace GameAi.Nodes
{
    public sealed class DebugLogNode<TContext> : BehaviorTreeNodeBase<TContext>
    {
        private readonly Func<TContext, string> _message;

        public DebugLogNode(Func<TContext, string> message) => _message = message;

        public override EvaluationStatus Evaluate(TContext context)
        {
            Debug.Log(_message(context));
            return EvaluationStatus.Success;
        }
    }
}
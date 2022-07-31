using System;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;

namespace Game.Ai.Nodes
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
using System.Collections.Generic;

namespace BehaviorTrees.Nodes.Composite
{
    public sealed class BehaviorTreeSequenceNode<TContext> : BehaviorTreeCompositeNodeBase<TContext>
    {
        public BehaviorTreeSequenceNode(IEnumerable<IBehaviorTreeNode<TContext>> nodes) : base(nodes) { }

        protected override EvaluationStatus EvaluateComposite(IReadOnlyList<IBehaviorTreeNode<TContext>> nodes,
            TContext context)
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index < nodes.Count; index++)
            {
                var node = nodes[index];
                var status = node.Evaluate(context);
                if (status != EvaluationStatus.Success)
                    return status;
            }

            return EvaluationStatus.Success;
        }
    }
}
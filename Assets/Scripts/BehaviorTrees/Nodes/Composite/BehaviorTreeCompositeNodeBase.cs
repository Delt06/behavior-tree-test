using System.Collections.Generic;
using System.Linq;

namespace BehaviorTrees.Nodes.Composite
{
    public abstract class BehaviorTreeCompositeNodeBase<TContext> : BehaviorTreeNodeBase<TContext>
    {
        private readonly IReadOnlyList<IBehaviorTreeNode<TContext>> _nodes;

        protected BehaviorTreeCompositeNodeBase(IEnumerable<IBehaviorTreeNode<TContext>> nodes) =>
            _nodes = nodes.ToArray();

        public sealed override EvaluationStatus Evaluate(TContext context) => EvaluateComposite(_nodes, context);

        public sealed override void ResetState(TContext context)
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var index = 0; index < _nodes.Count; index++)
            {
                var node = _nodes[index];
                node.ResetState(context);
            }
        }

        protected abstract EvaluationStatus EvaluateComposite(IReadOnlyList<IBehaviorTreeNode<TContext>> nodes,
            TContext context);
    }
}
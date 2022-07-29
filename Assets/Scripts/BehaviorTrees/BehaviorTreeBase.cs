using System;
using BehaviorTrees.Nodes;

namespace BehaviorTrees
{
    public abstract class BehaviorTreeBase<TContext>
    {
        private IBehaviorTreeNode<TContext> _tree;

        public void Setup() => _tree = CreateTree();

        public void Update(TContext context)
        {
            EnsureSetup();
            var evaluationStatus = _tree.Evaluate(context);
            if (evaluationStatus != EvaluationStatus.Running)
                _tree.ResetState(context);
        }

        private void EnsureSetup()
        {
            if (_tree == null)
                throw new InvalidOperationException("BehaviorTree is not ready. Execute Setup first.");
        }

        protected abstract IBehaviorTreeNode<TContext> CreateTree();

        public void ResetState(TContext context)
        {
            EnsureSetup();
            _tree.ResetState(context);
        }
    }
}